import React, { Component } from 'react';
import { AppRegistry } from 'react-native';

//components
import PanelCollapsibleTest from './app/PanelCollapsibleTest';
import PanelLogTest from './app/PanelLogTest';
import TinderCardTest from './app/TinderCardTest';

//animations
import AnimationBasic from './app/AnimationBasic';

export default class MyComponents extends Component {
  render() {
    return <PanelLogTest />
  }
}

AppRegistry.registerComponent('MyComponents', () => MyComponents);
