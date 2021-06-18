import React, {useState} from 'react'
import Select from 'react-select'

const options = [
  { value: 'LG', label: 'Logies' },
  { value: 'LO', label: 'Logies objict' },
  { value: 'HB', label: 'Half Pension' },
  { value: 'AI', label: 'All inclusive' }
]

export default function FilterPackages({onSubmit, onCancel}) {
  const [mealPlan, setMealPlan] = useState('LG')

  const activeOption = options.find(o => o.value === mealPlan)

  const submit = e => {
    e.preventDefault()
    onSubmit({mealPlan})
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
          <a className="error button" onClick={cancel}>cancel</a>          
          <button type="submit" name="submit">add filters</button>
        </form>
      </div>
    </div>
  )
}
