import React, { Component } from 'react';
import { AppRegistry, View } from 'react-native';
import { Router, Scene, Actions } from 'react-native-router-flux';
import { SideMenu, List, ListItem } from 'react-native-elements'

//components
import PanelCollapsibleTest from './app/PanelCollapsibleTest';
import PanelLogTest from './app/PanelLogTest';
import TinderCardTest from './app/TinderCardTest';

//animations
import AnimationBasic from './app/AnimationBasic';

export default class MyComponents extends Component {
  constructor() {
    super()
    this.state = {
      isOpen: false
    }
    this.hideSideMenu = this.hideSideMenu.bind(this);
    this.navigate = this.navigate.bind(this);
  }

  onSideMenuChange(isOpen) {
    this.setState({
      isOpen: isOpen
    })
  }

  hideSideMenu() {
    this.setState({
      isOpen: false
    })
  }

  navigate(action) {
    action();
    this.hideSideMenu();
  }

  render() {
    const MenuComponent = (
      <View style={{ flex: 1, backgroundColor: '#03A9F4', paddingTop: 50 }}>
        <List containerStyle={{ marginBottom: 20 }}>
          <ListItem onPress={() => this.navigate(Actions.PanelCollapsibleTest)} key={1} title="PanelCollapsible" />
          <ListItem onPress={() => this.navigate(Actions.PanelLogTest)} key={2} title="PanelLog" />
          <ListItem onPress={() => this.navigate(Actions.TinderCardTest)} key={3} title="TinderCard" />
          <ListItem onPress={() => this.navigate(Actions.AnimationBasic)} key={4} title="AnimationBasic" />
        </List>
      </View>
    )

    return <View style={{ flex: 1 }}>


      <SideMenu
        isOpen={this.state.isOpen}
        onChange={this.onSideMenuChange.bind(this)}
        menu={MenuComponent}>
        <Router>
          <Scene key="root" hideNavBar={true}>
            <Scene key="PanelCollapsibleTest" component={PanelCollapsibleTest} title="PanelCollapsible Test" initial={true} />
            <Scene key="PanelLogTest" component={PanelLogTest} title="PanelLog Test" />
            <Scene key="TinderCardTest" component={TinderCardTest} title="TinderCard Test" />
            <Scene key="AnimationBasic" component={AnimationBasic} title="Animation Basic" />
          </Scene>
        </Router>
      </SideMenu>
    </View>
  }
}

AppRegistry.registerComponent('MyComponents', () => MyComponents);
