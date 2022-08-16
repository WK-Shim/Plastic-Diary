import React, { Component } from "react";
import { ScrollView, View, Text, StyleSheet } from "react-native";
import { styles } from "./style.js";

class MainView extends Component {
    render() {
        return (
            <View style={styles.container}>
                <View style={styles.topBar}>
                    <Text style={styles.titleText}>플라스틱 다이어리 - 리포트</Text>
                </View>
                
                <View style={styles.scrollView}>
                <ScrollView>
                    <Text>Hello world</Text>
                </ScrollView>
                </View>
            </View>
        );
    }
}

export default MainView;