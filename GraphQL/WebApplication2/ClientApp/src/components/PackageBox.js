import React from 'react'

const PackageBox = ({pack}) => (
  <div className="pet">
    <div className="pet-name">{pack.accommodationId}</div>
    <div className="pet-type">{pack.mealplan.code}</div>
    <div className="pet-type">{pack.mealplan.description}</div>
    <div className="pet-type">{pack.averagePrice.amount}</div>
  </div>
)

export default PackageBox
