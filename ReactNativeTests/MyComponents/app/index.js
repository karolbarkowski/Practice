import React from 'react';
import { View, StyleSheet } from 'react-native';
import { Button } from 'react-native-elements';

//components
import PanelCollapsibleTest from './componentTests/PanelCollapsibleTest';
import PanelLogTest from './componentTests/PanelLogTest';
import TinderCardTest from './componentTests/TinderCardTest';

//animations
import AnimationBasic from './animationTests/AnimationBasic';


export default class Index extends React.Component {
   navigate(module) {
      const { navigation } = this.props;
      navigation.navigate(module);
   }

   render() {
      return (
         <View style={styles.container}>
            <Button
               onPress={() => this.navigate('PanelLogTest')}
               buttonStyle={styles.button}
               title="Panel Log"
            />
            <Button
               onPress={() => this.navigate('PanelCollapsibleTest')}
               buttonStyle={styles.button}
               title="Panel Collapsible"
            />
            <Button
               onPress={() => this.navigate('TinderCardTest')}
               buttonStyle={styles.button}
               title="Panel Tinder Cards"
            />
            <Button
               onPress={() => this.navigate('AnimationBasic')}
               buttonStyle={styles.button}
               title="Animation Basic"
            />
         </View>
      );
   }
};

const styles = StyleSheet.create({
   container: {
      flex: 1,
      justifyContent: 'center'
   },
   button: {
      backgroundColor: "#03A9F4",
      marginBottom: 30
   }
});