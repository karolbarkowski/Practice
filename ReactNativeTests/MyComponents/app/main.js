import React from 'react';
import { StackNavigator, TabNavigator } from 'react-navigation';

import Index from './index';

//components
import PanelCollapsibleTest from './componentTests/PanelCollapsibleTest';
import PanelLogTest from './componentTests/PanelLogTest';
import TinderCardTest from './componentTests/TinderCardTest';

//animations
import AnimationBasic from './animationTests/AnimationBasic';

//navigation
import ModalTest from './navigationTests/ModalTest';
import Tab1 from './navigationTests/testViews/Tab1';
import Tab2 from './navigationTests/testViews/Tab2';
import Modal1 from './navigationTests/testViews/Modal1';

export default class Main extends React.Component {
   render() {
      const ModalTestRouter = StackNavigator({
         ModalTest: {
            screen: ModalTest,
            navigationOptions: {
               title: 'Modal Window Test',
            }
         },
         ModalTestPopup: {
            screen: Modal1,
            navigationOptions: {
               title: 'Modal View Title',
            }
         }
      }, {
            mode: 'modal',
            headerMode: 'none'
         });

      const TabsTestRouter = TabNavigator({
         Tab1: {
            screen: Tab1
         },
         Tab2: {
            screen: Tab2
         }
      });

      const Root = StackNavigator({
         Index: {
            screen: Index,
            navigationOptions: {
               headerVisible: false,
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
         },
         TabsTest: {
            screen: TabsTestRouter,
            navigationOptions: {
               title: 'Tabs Layout Test'
            }
         },
         ModalTest: {
            screen: ModalTestRouter
         }
      });

      return <Root />;
   }
};

