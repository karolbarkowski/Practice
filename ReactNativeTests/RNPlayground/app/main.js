import React from 'react';
import { StackNavigator, TabNavigator } from 'react-navigation';

import Index from './index';

//components
import PanelCollapsibleTest from './componentTests/PanelCollapsibleTest';
import PanelLogTest from './componentTests/PanelLogTest';
import TinderCardTest from './componentTests/TinderCardTest';

//animations
import AnimationBasic from './animationTests/AnimationBasic';


export default class Main extends React.Component {
      render() {

            const Root = StackNavigator({
                  Index: {
                        screen: PanelCollapsibleTest,
                        navigationOptions: {
                              title: 'Tests Pages'
                        }
                  },
                  PanelCollapsibleTest: {
                        screen: PanelCollapsibleTest,
                        navigationOptions: {
                              title: 'Collapsible Panel Test'
                        }
                  },
                  PanelLogTest: {
                        screen: PanelLogTest,
                        navigationOptions: {
                              title: 'Log Panel Test',
                        }
                  },
                  TinderCardTest: {
                        screen: TinderCardTest,
                        navigationOptions: {
                              title: 'Tinder Cards Test',
                        }
                  },
                  AnimationBasic: {
                        screen: AnimationBasic,
                        navigationOptions: {
                              title: 'Basic Animation',
                        }
                  }
            });

            return <Root />;
      }
};

