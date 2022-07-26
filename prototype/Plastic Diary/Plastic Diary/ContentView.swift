//
//  ContentView.swift
//  Plastic Diary
//
//  Created by 심우경 on 2022/06/17.
//

import SwiftUI

let green = UIColor.systemTeal

struct ContentView: View {
    var body: some View {
        VStack() {
            ZStack() {
                Color(green).ignoresSafeArea()
                
                VStack(alignment: .trailing) {
                    HStack() {
                        Text("리포트")
                            .foregroundColor(.white)
                            .font(.title2)
                            .bold()
                        
                        Spacer()
                    }.padding()
                    
                    Spacer()
                    
                    HStack() {
                        Spacer()
                        
                        Button(action: newDiary) {
                            HStack() {
                                Text("일기 쓰기")
                                    .foregroundColor(.white)
                                
                                Image(systemName: "square.and.pencil")
                                    .foregroundColor(.white)
                                    .font(.system(size: 16))
                            }
                        }
                            .padding()
                    }
                }
            }.frame(width: .infinity, height: 120)
            
            List() {
                Section(header: Text("플라스틱 사용량")) {
                    HStack(alignment: .bottom) {
                        Spacer()
                        
                        VStack() {
                            Text("이번 주 사용량")
                                .bold()
                                .foregroundColor(.red)
                                .frame(width: 100, height: 25)
                            
                            Text("158 kg")
                        }.padding()
                        
                        VStack() {
                            Text("지난 주 사용량")
                                .bold()
                                .foregroundColor(.blue)
                                .frame(width: 100, height: 25)
                            
                            Text("170 kg")
                        }.padding()
                        
                        Spacer()
                    }
                }
                
                Section(header: Text("사용량 변화")) {
                    
                }
            }
            Spacer()
        }
    }
}

struct ContentView_Previews: PreviewProvider {
    static var previews: some View {
        ContentView()
    }
}

func newDiary() {
    print("newDiary")
}
