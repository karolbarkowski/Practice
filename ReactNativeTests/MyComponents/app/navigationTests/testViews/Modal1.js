import React from 'react';
import { View, Text } from 'react-native';

export default class Modal1 extends React.Component {
   render() {
      return (
         <View style={{ flex: 1, justifyContent: 'center', alignItems: 'center' }}>
            <Text>Hello From Modal 1</Text>
         </View>
      )
   }
}