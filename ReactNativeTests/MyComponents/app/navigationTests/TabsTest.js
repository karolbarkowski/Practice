import React from 'react';
import { View } from 'react-native';
import { TabNavigator } from 'react-navigation';
import { Icon } from 'react-native-elements';

import Tab1 from './Tab1';
import Tab2 from './Tab2';

export default class TabsTest extends React.Component {
   render() {
      const TabsTest = TabNavigator({
         Tab1: {
            screen: Tab1,
            navigationOptions: {
               topBarLabel: 'tab 1',
               tabBar: ({ tintColor }) => <Icon name="list" size={35} />,
            },
         },
         Tab2: {
            screen: Tab2,
            navigationOptions: {
               topBarLabel: 'tab 2',
               tabBar: ({ tintColor }) => <Icon name="list" size={35} />,
            },
         },
      },
      // {
      //    tabBarOptions: {
      //       activeTintColor: '#e91e63',
      //    }
      // }
      );

      return (
         <TabsTest />
      )
   }
}