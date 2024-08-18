import { Image, Text, TouchableOpacity, View } from "react-native";
import logo from '../assets/images/logo.png';
import { StatusBar } from "expo-status-bar";
import CustomButton from "@/app/components/CustomButton";

export default function Index() {
  return (
    <View className="flex flex-1 items-center justify-center bg-slate-900">
      <StatusBar style="dark" />
      <Image height={50} className="w-[400px] h-[200px] mb-12" width={30} resizeMode="contain" source={logo} />
      <CustomButton text="Criar conta" buttonStyles="bg-yellow-500 mb-4" textStyles="text-gray-50" onPress={() => console.log('Button pressed')} />
      <CustomButton text="Entrar" buttonStyles="bg-slate-500 mb-4" textStyles="text-gray-50" onPress={() => console.log('Button pressed')} />
      <TouchableOpacity>
        <Text className="text-slate-100">Entrar como convidado</Text>
      </TouchableOpacity>
    </View>
  );
}
