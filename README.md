Tikitaka

Tikitaka는 공을 움직여 골대를 맞추는 축구 게임으로 유니티와 C#으로 구현되었습니다.

담당한 기능
- PlayerPrefs을 이용한 유저 임시 저장 및 유저 랭킹
- 플레이어(공)의 가속도를 이용한 움직임 구현
- 골키퍼의 공을 따라가는 움직임 구현
- 공의 생명과 포인트 점수 계산
- 오브젝트 풀링을 이용한 랜덤 아이템 박스

주요 스크립트 파일들
https://github.com/dd6679/Tikitaka/tree/main/Assets/NK/Scripts
NK_Box.cs:

기능: 박스 오브젝트와 관련된 로직을 처리하는 스크립트.
주요 메서드: 박스의 생성, 충돌 처리, 상태 업데이트 등.
NK_EndingScene.cs:

기능: 게임의 엔딩 씬을 관리하는 스크립트.
주요 메서드: 엔딩 씬의 초기화, 씬 전환, 엔딩 조건 확인 등.
NK_Enemy.cs:

기능: 적 캐릭터의 동작과 상태를 관리하는 스크립트.
주요 메서드: 적의 이동, 공격, 피해 처리 등.
NK_FogItem.cs:

기능: 안개 아이템과 관련된 로직을 처리하는 스크립트.
주요 메서드: 아이템의 활성화, 효과 적용 등.
NK_GoalKeeper.cs:

기능: 골키퍼 캐릭터의 동작을 관리하는 스크립트.
주요 메서드: 골키퍼의 위치 제어, 공 차단 동작 등.
NK_Item.cs:

기능: 일반 아이템과 관련된 로직을 처리하는 스크립트.
주요 메서드: 아이템의 생성, 사용, 효과 적용 등.
NK_SpawnManager.cs:

기능: 게임 오브젝트의 스폰을 관리하는 스크립트.
주요 메서드: 스폰 위치 설정, 주기적 스폰, 스폰 조건 확인 등.
