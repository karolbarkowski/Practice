import React, { Component } from 'react';
import { AppRegistry } from 'react-native';

import ComponentsList from './app/ComponentsList';
import TinderCardTest from './app/TinderCardTest';
import AnimationBasic from './app/AnimationBasic';

export default class MyComponents extends Component {
  render() {
    return <TinderCardTest />
  }
}

AppRegistry.registerComponent('MyComponents', () => MyComponents);
