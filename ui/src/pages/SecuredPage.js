import { gql, useQuery } from "@apollo/client";
import { useKeycloak } from "@react-keycloak/web";
import { Card, CardBody, CardFooter, CardHeader, Center, HStack, Text, VStack } from "@chakra-ui/react"

const NOTE_BY_ID = gql`
    {
        noteById(id: 1) {
            id
            title
            description
            creatorId
        }
    }
`

const SecuredPage = () => {
    const { keycloak, initialized } = useKeycloak();
    const { 
        data, 
        loading, 
        error, 
        refetch 
    } = useQuery(NOTE_BY_ID);

    if (loading) {
        return (
            <Center>
                <Text as="b">Loading...</Text>
            </Center>
        )
    } 
    if (error) {
        return (
            <Center>
                <pre>ERROR!!!</pre>
            </Center>
        )
    } 

    

    return (
        <Center>
            <VStack>
                <Text>
                    Congratulations you are on secured page!
                    Under this text you can see a card white note information.
                    Request, which get note by ID works only for authorized users.
                </Text>

                <Card m="5" w="fit-content">
                    <CardHeader>
                        <Text as="b">
                            #{data.noteById.id} {data.noteById.title}
                        </Text>
                    </CardHeader>
                    <CardBody>
                        {data.noteById.description}
                    </CardBody>
                    <CardFooter>
                        <Text as="i">
                            {data.noteById.creatorId}
                        </Text>
                    </CardFooter>
                </Card>
            </VStack>
        </Center>
    )
}

export default SecuredPage;
