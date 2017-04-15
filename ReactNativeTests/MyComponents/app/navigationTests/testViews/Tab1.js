import React from 'react';
import { View, Text } from 'react-native';
import { Button } from 'react-native-elements';

export default class Tabs1 extends React.Component {
   render() {
      return (
         <View style={{ flex: 1, justifyContent: 'center', alignItems: 'center' }}>
            <Text>Hello From Tab 1</Text>
         </View>
      )
   }
}