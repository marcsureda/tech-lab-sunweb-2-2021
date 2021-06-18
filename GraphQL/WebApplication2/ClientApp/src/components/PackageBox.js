import React from 'react'

const PackageBox = ({pack}) => (
  <div className="pet">
      <figure>
          <img src={pack.accommodation.accoImageUrl} alt=""/>
      </figure>
    <div className="pet-name">{pack.accommodationId} - {pack.accommodation.name}</div>
    <div className="pet-type">{pack.mealplan.code}</div>
    <div className="pet-type">{pack.mealplan.description}</div>
    <div className="pet-type">{pack.averagePrice.amount}</div>
  </div>
)

export default PackageBox
