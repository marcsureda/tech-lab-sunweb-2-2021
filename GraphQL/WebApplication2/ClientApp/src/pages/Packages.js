import React, {useState} from 'react'
import gql from 'graphql-tag'
import PackageBox from '../components/PackageBox'
import { useQuery } from '@apollo/react-hooks'
import Loader from '../components/Loader'
import FilterPackages from "../components/FilterPackages";


export default function Packages () {
  const [modal, setModal] = useState(false)
  const [mealplan, setMealPlan] = useState ('')
  const [averagePrice, setAveragePrice] = useState (0)
  const [sortByPrice, setSortByPrice] = useState (false)

  const mealplanFilter = (mealplan !== '' && mealplan !== undefined) ? `mealplan:{
        code:{eq:"${mealplan}"}
      }` : ``

  const averagePriceFilter = (averagePrice > 0 && averagePrice !== undefined) ?
    `averagePrice:{ 
      amount:{lt:${averagePrice}}
    }` : ``

  const whereFilter = averagePriceFilter !== '' || mealplanFilter !== '' ?
    `where:{
      ${mealplanFilter}
      ${averagePriceFilter}
    }` : ``

  const sortFilter = sortByPrice ?
    `order: {
      averagePrice:{
        amount:ASC
        }
    }` : ``

  const packagesWhereAndSort = whereFilter !== '' || sortFilter !== '' ?
    `(${whereFilter}
    ${sortFilter})` : ``

  const GET_PACKAGES = gql`
  query{
  packages
  ${packagesWhereAndSort}
  {
    accommodationId
    departureDate
    mealplan {
      code
      description
    }
    averagePrice { amount }
    rooms {
      occupancy {
        adultsCount
        childrenCount
        babiesCount
      }
    }
  }
}
`


  const packages = useQuery(GET_PACKAGES)

  /*const [createPet, newPet] = useMutation(CREATE_PET, {
    update(cache, { data: { addPet } }) {
      const { pets } = cache.readQuery({ query: GET_PETS })

      cache.writeQuery({
        query: GET_PETS,
        data: { pets: [addPet, ...pets] }
      })
    }
  })*/

  if (packages.loading) return <Loader />
  if (packages.error
  ) return <p>ERROR</p>

  const onSubmit = input => {
    setModal(false)
    setMealPlan(input.mealPlan)
    console.log(input)
    setAveragePrice(input.averagePrice)
    setSortByPrice(input.sortByPrice)
  }

  const packagesList = packages.data.packages.map(pack => (
    <div className="col-xs-12 col-md-4 col" key={pack.accommodationId}>
      <div className="box">
        <PackageBox pack={pack} />
      </div>
    </div>
  ))
  
  if (modal) {
    return (
      <div className="row center-xs">
        <div className="col-xs-8">
          <FilterPackages onSubmit={onSubmit} onCancel={() => setModal(false)}/>
        </div>
      </div>
    )
  }

  return (
    <div className="page pets-page">
      <section>
        <div className="row betwee-xs middle-xs">
          <div className="col-xs-10">
            <h1>Packages</h1>
          </div>

          <div className="col-xs-2">
            <button onClick={() => setModal(true)}>Filter data</button>
          </div>
        </div>
      </section>
      <section>
        <div className="row">
          {packagesList}
        </div>
      </section>
    </div>
  )
}
