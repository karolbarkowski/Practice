import React from 'react';
import { View, Text } from 'react-native';
import { Button } from 'react-native-elements';

export default class TabsTest extends React.Component {
   render() {
      return (
         <View style={{ flex: 1, justifyContent: 'center', alignItems: 'center' }}>
            <Button
               onPress={() => this.props.navigation.navigate('ModalTestPopup')}
               backgroundColor="#03A9F4"
               title="Bring up the MODAL"
            />
         </View>
      )
   }
}