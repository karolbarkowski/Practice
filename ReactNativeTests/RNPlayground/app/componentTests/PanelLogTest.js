import React from 'react';
import { View, StyleSheet } from 'react-native';
import { PanelLog } from './../../components/ComponentsIndex';
import { Button } from 'react-native-elements';

export default class PanelLogTest extends React.Component {
  logMessage() {
    this.refs.panelLog.Log('Sample message ' + new Date().getTime());
  }

  render() {
    return (
      <View style={styles.container}>
        <PanelLog ref="panelLog" maxMessagesCount={50} />

        <Button
          onPress={this.logMessage.bind(this)}
          buttonStyle={{ marginBottom: 30 }}
          backgroundColor="#03A9F4"
          title="Log Message"
        />
      </View>
    );
  }
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    flexDirection: 'column',
    justifyContent: 'flex-end',
    backgroundColor: '#F5FCFF'
  }
});