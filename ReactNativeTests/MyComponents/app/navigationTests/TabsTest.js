import React from 'react';
import { View } from 'react-native';

export default class TabsTest extends React.Component {
   static navigationOptions = ({ navigation }) => ({
      title: 'Tabbed layout test',
   });

   render() {
      return (
         <View></View>
      )
   }
}