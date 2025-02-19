// Copyright 2024 Google Inc.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

// [START pubsub_create_cloud_storage_subscription]

using Google.Cloud.PubSub.V1;
using Google.Protobuf.WellKnownTypes;
using System;

public class CreateCloudStorageSubscriptionSample
{
    public Subscription CreateCloudStorageSubscription(string projectId, string topicId, string subscriptionId,
        string bucket, string filenamePrefix, string filenameSuffix, TimeSpan maxDuration)
    {
        SubscriberServiceApiClient subscriber = SubscriberServiceApiClient.Create();
        TopicName topicName = TopicName.FromProjectTopic(projectId, topicId);
        SubscriptionName subscriptionName = SubscriptionName.FromProjectSubscription(projectId, subscriptionId);

        var subscriptionRequest = new Subscription
        {
            SubscriptionName = subscriptionName,
            TopicAsTopicName = topicName,
            CloudStorageConfig = new CloudStorageConfig
            {
                Bucket = bucket,
                FilenamePrefix = filenamePrefix,
                FilenameSuffix = filenameSuffix,
                MaxDuration = Duration.FromTimeSpan(maxDuration)
            }
        };
        var subscription = subscriber.CreateSubscription(subscriptionRequest);
        return subscription;
    }
}
// [END pubsub_create_cloud_storage_subscription]
