import React from 'react';
import { View, StyleSheet } from 'react-native';
import { PanelLog } from './../../components/ComponentsIndex';
import { Button } from 'react-native-elements';

export default class PanelLogTest extends React.Component {
  logMessage() {
    this.refs.panelLog.Log('Sample message ' + new Date().getTime());
  }

  renderButtons() {
    let buttons = [];

    for (let i = 0; i < 10; i++) {
      buttons.push(<View key={i} style={{ marginTop: 20, marginBottom: 20 }}>
        <Button
          onPress={this.logMessage.bind(this)}
          backgroundColor="#03A9F4"
          title="Log Message"
        />
      </View>);
    }
    return buttons;
  }

  render() {
    return (
      <View style={styles.container}>
        <PanelLog ref="panelLog" maxMessagesCount={50} />

        {this.renderButtons()}
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