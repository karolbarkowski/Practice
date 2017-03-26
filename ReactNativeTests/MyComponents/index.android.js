import React, { Component } from 'react';
import {
  AppRegistry,
  StyleSheet,
  Text,
  View
} from 'react-native';
import { PanelCollapsible, PanelLog } from './components/ComponentsIndex';

export default class MyComponents extends Component {
  render() {
    return (
      <View style={styles.container}>
        <PanelLog />

        <PanelCollapsible title="My Test Title">
          <Text>My Test Collapsible panel body</Text>
          <Text>My Test Collapsible panel body</Text>
          <Text>My Test Collapsible panel body</Text>
          <Text>My Test Collapsible panel body</Text>
        </PanelCollapsible>

        <PanelCollapsible title="My Test Title 2" duration={1000}>
          <Text>My Test Collapsible panel body</Text>
        </PanelCollapsible>

        <PanelCollapsible title="My Test Title 3">
          <Text>My Test Collapsible panel body</Text>
          <Text>My Test Collapsible panel body</Text>
          <Text>My Test Collapsible panel body</Text>
          <Text>My Test Collapsible panel body</Text>
          <Text>My Test Collapsible panel body</Text>
          <Text>My Test Collapsible panel body</Text>
          <Text>My Test Collapsible panel body</Text>
          <Text>My Test Collapsible anel body</Text>
        </PanelCollapsible>
      </View>
    );
  }
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: '#F5FCFF'
  }
});

AppRegistry.registerComponent('MyComponents', () => MyComponents);
