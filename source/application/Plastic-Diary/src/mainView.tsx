import React, { Component } from "react";
import { ScrollView, View, Text } from "react-native";
import { styles } from "./style.js";

class MainView extends Component {
    render() {
        return (
            <View>
                <View style={styles.topBar}>
                    <Text>"리포트"</Text>
                </View>
                <View style={styles.scrollView}>
                    <Text>Scroll</Text>
                </View>
            </View>
        );
    }
}

export default MainView;