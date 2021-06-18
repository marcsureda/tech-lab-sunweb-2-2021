import { Switch, Route } from 'react-router-dom'
import React, {Fragment} from 'react'
import Header from './Header'
import Packages from '../pages/Packages'

const App = () => (
  <Fragment>
    <Header />
    <div>
      <Switch>
        <Route exact path="/" component={Packages} />
      </Switch>
    </div>
  </Fragment>
)

export default App
