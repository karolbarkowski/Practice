import React, { Component } from 'react';
import { AppRegistry } from 'react-native';

import ComponentsList from './app/ComponentsList';
import AnimationBasic from './app/AnimationBasic';

export default class MyComponents extends Component {
  render() {
    return <AnimationBasic />
  }
}

AppRegistry.registerComponent('MyComponents', () => MyComponents);
