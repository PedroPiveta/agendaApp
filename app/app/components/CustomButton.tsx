import { View, Text } from 'react-native'
import React from 'react'
import { TouchableOpacity } from 'react-native'

type CustomButtonProps = {
  text: string,
  buttonStyles?: string,
  textStyles?: string,
  onPress: () => void
}

const CustomButton = ({ text, onPress, buttonStyles, textStyles }: CustomButtonProps) => {
  return (
    <TouchableOpacity className={`w-80 h-10 items-center justify-center rounded-lg ${buttonStyles} shadow-md shadow-gray-50`}>
      <Text className={`font-bold text-lg ${textStyles}`}>{ text }</Text>
    </TouchableOpacity>
  )
}

export default CustomButton