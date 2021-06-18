import React, {useState} from 'react'
import Select from 'react-select'

const options = [
  { value: '', label: 'No mealplan' },
  { value: 'LG', label: 'Logies' },
  { value: 'LO', label: 'Logies ontbijt' },
  { value: 'HB', label: 'Half Pension' },
  { value: 'AI', label: 'All inclusive' }
]

export default function FilterPackages({onSubmit, onCancel}) {
  const [mealPlan, setMealPlan] = useState('')
  const [averagePrice, setAveragePrice] = useState('')
  // const [sortByPrice, setSortByPrice] = useState(false)
  const activeOption = options.find(o => o.value === mealPlan)

  const submit = e => {
    e.preventDefault()
    onSubmit({mealPlan, averagePrice})
    // onSubmit({mealPlan, averagePrice, sortByPrice})
  }

  const cancel = e => {
    e.preventDefault()
    onCancel()
  }

  return (
    <div className="new-pet page">
      <h1>Set Filters</h1>
      <div className="box">
        <form onSubmit={submit}>
          <Select
            value={activeOption}
            defaultValue={options[0]}
            onChange={e => setMealPlan(e.value)}
            options={options}
        />
          <input type="number" className="input" min="0" value={averagePrice} onChange={e => setAveragePrice(e.target.value)} />
          {/* <input type="checkbox" className="input" value={sortByPrice} onChange={e => setSortByPrice(e.value)} /> */}
          <a className="error button" onClick={cancel}>cancel</a>          
          <button type="submit" name="submit">add filters</button>
        </form>
      </div>
    </div>
  )
}
