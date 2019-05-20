import React from 'react';
import AppBar from "./components/AppBar";
import { BrowserRouter as Router, Switch, Route, NavLink } from 'react-router-dom';
import Home from "./components/Home";
import Memory from "./components/Memory";
import withStyles from 'react-jss';

const App = ({classes}) => (
    <div>
        <Router>
            <AppBar>
                <span className={classes.title}>Memory App</span>
                <NavLink className={classes.navLink} to="/">Home</NavLink>
                <NavLink className={classes.navLink} to="/memory">Memory</NavLink>
            </AppBar>
            <Switch>
                <Route path="/memory" component={Memory}/>
                <Route path="/" component={Home}/>
            </Switch>
        </Router>
    </div>
);

const styles = {
    title: {
      padding: '0 30px 0 10px',
      fontSize: '1.5rem',  
    },
    navLink: {
        color: 'white',
        padding: '20px',
        textDecoration: 'none',
        display: 'inline-block',
        '&:hover': {
            backgroundColor: '#cc3300'
        }
    }
};

export default withStyles(styles)(App);
