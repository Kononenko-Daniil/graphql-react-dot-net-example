import { Button, Card, CardBody, CardFooter, CardHeader, Center, HStack, Text, VStack } from "@chakra-ui/react"
import { useQuery, gql, useMutation  } from "@apollo/client";
import { useEffect } from "react";

const NOTES_QUERY = gql`
    {
        notes {
            id
            title
            description
            creatorId
        }
    }
`

const ADD_NOTES_MUTATION = gql`
    mutation {
        fillNoteTable
    }
`

const HomePage = () => {
    const { 
        data, 
        loading, 
        error, 
        refetch 
    } = useQuery(NOTES_QUERY);
    const [
        addNotesMutation, { 
            addNotesMutationResult, 
            addNotesMutationLoading, 
            addNotesMutationError, 
            addNotesMutationCalled, 
            addNotesMutationReset 
        }
    ] = useMutation(ADD_NOTES_MUTATION);

    if (loading || addNotesMutationLoading) {
        return (
            <Center>
                <Text as="b">Loading...</Text>
            </Center>
        )
    } 
    if (error || addNotesMutationError) {
        return (
            <Center>
                <pre>ERROR!!!</pre>
            </Center>
        )
    } 

    const addNotesClick = () => {
        addNotesMutation();
        refetch();
    }

    return (
        <Center>
            <VStack>
                <Text fontSize='lg' align={"center"}>
                    You are on home page. Under this text you can see all notes,
                    that are currently in database. You don't need to be authorized
                    to see them. <br/> Here you can see on bug - after first "Add" click nothing changing.
                    This problem is connected with asynchronous lyfecycle of React Hooks. This is not a problem of
                    graphql. 
                </Text>
                <Button onClick={addNotesClick}>Add notes</Button>
                <Center>
                    <HStack mt="20" flexWrap={"wrap"} alignItems={"center"} justifyContent={"center"}>
                        {
                            data.notes.map((note, index) => 
                                <Card m="5" key={index} w="fit-content">
                                    <CardHeader>
                                        <Text as="b">
                                            #{note.id} {note.title}
                                        </Text>
                                    </CardHeader>
                                    <CardBody>
                                        {note.description}
                                    </CardBody>
                                    <CardFooter>
                                        <Text as="i">
                                            {note.creatorId}
                                        </Text>
                                    </CardFooter>
                                </Card>
                            )
                        }
                    </HStack>
                </Center>
            </VStack>
        </Center>
    )
}

export default HomePage;
