import React from 'react';
import { View, ScrollView, StyleSheet } from 'react-native';
import { Button, Card } from 'react-native-elements';

export default class Index extends React.Component {
   navigate(module) {
      const { navigation } = this.props;
      navigation.navigate(module);
   }

   render() {
      return (
         <ScrollView style={styles.container}>
            <Card title="Components">
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
                  buttonStyle={[styles.button, styles.buttonLast]}
                  title="Panel Tinder Cards"
               />
            </Card>
            <Card title="Animations">
               <Button
                  onPress={() => this.navigate('AnimationBasic')}
                  buttonStyle={[styles.button, styles.buttonLast]}
                  title="Animation Basic"
               />
            </Card>
         </ScrollView>
      );
   }
};

const styles = StyleSheet.create({
   container: {
      flex: 1,
   },
   button: {
      backgroundColor: "#03A9F4",
      marginBottom: 10
   },
   buttonLast: {
      marginBottom: 0
   }
});