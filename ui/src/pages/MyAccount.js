import { EmailIcon } from "@chakra-ui/icons";
import { Avatar, Card, Center, Text, VStack, Icon } from "@chakra-ui/react";
import { useKeycloak } from "@react-keycloak/web";
import { useEffect } from "react";

const MyAccount = () => {
    const { keycloak, initialized } = useKeycloak();
    console.log(keycloak);

    useEffect(() => {
        fetch("https://localhost:7209/user/me", {method: 'GET', headers: {
            'Authorization': `Bearer ${keycloak.token}`
        }}).then((res) => {res.text()}).then((response) => {console.log(response)});
    }, []);

    return (
        <>
            <Card p={6}>
                <Center>
                    <VStack>
                        <Avatar src='https://bit.ly/broken-link' size='xl' />
                        <Text fontSize={'4xl'}>{keycloak.tokenParsed.preferred_username}</Text>
                        <Text>
                            <EmailIcon me={3} />
                            {keycloak.tokenParsed.email}
                        </Text>
                    </VStack>
                </Center>
            </Card>
        </>
    )
}

export default MyAccount;
