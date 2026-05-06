# POCU C# 코딩 표준

## I. 메인 코딩 표준

### 네이밍

| 대상 | 규칙 | 예시 |
|:--|:--|:--|
| 클래스, 구조체 | 파스칼 표기법 | `CardManager`, `SCardInfo` |
| 지역 변수, 매개변수 | 카멜 표기법 | `cardName`, `targetIndex` |
| public 메서드 | 파스칼 표기법 | `GetCardName()` |
| non-public 메서드 | 카멜 표기법 | `calculateDamage()` |
| 상수 | 대문자 + 밑줄 | `MAX_HEALTH` |
| static readonly | 대문자 + 밑줄 | `DEFAULT_DECK_SIZE` |
| private 멤버 변수 | m + 파스칼 표기법 | `mCardName`, `mCurrentHp` |
| 부울 변수 | b 접두사 | `bIsAlive`, `bHasShield` |
| 부울 프로퍼티 | Is/Has/Can/Should 접두사 | `IsAlive`, `HasBuff` |
| 인터페이스 | I 접두사 | `IDamageable` |
| 열거형 | E 접두사 | `ECardType` |
| 구조체 | S 접두사 (readonly struct 제외) | `SDamageInfo` |
| 비트 플래그 열거형 | 이름 뒤에 Flags | `ECardTagFlags` |
| 네임스페이스 | 파스칼 표기법 | `CardSystem.Effects` |
| 재귀 함수 | 이름 뒤에 Recursive | `SearchRecursive()` |

### 메서드 네이밍 상세

- 기본 형태: 동사(명령형) + 명사(목적어) → `DrawCard()`, `ApplyDamage()`
- 부울 반환: Is/Can/Has/Should 또는 3인칭 단수형 동사 → `IsAlive()`, `Contains()`
- 값 반환: 무엇을 반환하는지 알 수 있게 → `GetCardName()`, `FindTargetOrNull()`
- null 반환 가능: 함수명 뒤에 OrNull → `GetCardOrNull()`
- null 허용 매개변수: 변수명 뒤에 OrNull → `Process(Card cardOrNull)`

### 변수 선언

- 줄임말이 뒤에 추가 단어 없이 단독 사용될 때: 모두 대문자 → `HTTP`, `ID`
- 단순 반복문 변수: `i`, `j` 허용
- 그 외: 데이터를 알 수 있는 이름 사용 → `index`, `employee` (❌ `e`)
- 지역 변수는 사용하는 코드와 동일한 줄에 선언
- 한 줄에 변수 하나만 선언
- 변수 가리기(variable shadowing) 금지
- out 매개변수는 별도 라인에 선언 (인자 목록 안에서 선언 금지)

### 타입과 키워드

- getter/setter 대신 프로퍼티 사용
- `double`이 필수가 아니면 부동소수점 값에 `f` 붙이기 → `3.14f`
- `var` 사용 자제. 우항에서 타입이 명확하거나 타입이 중요하지 않을 때만 예외 허용
- `System.Collections` 대신 `System.Collections.Generic` 사용. 순수 배열도 가능
- 상수 객체형 변수: `static readonly` 사용
- 초기화 후 불변 변수: `readonly` 선언
- `new` 키워드 뒤에 반드시 명시적 자료형

### 함수 설계

- 매개변수 자료형이 범용적인 경우 함수 오버로딩 피하기
- 디폴트 매개변수 대신 함수 오버로딩 선호
- 디폴트 매개변수 사용 시: `null`, `false`, `0` (비트 패턴 0인 값)만 허용
- 매개변수로 null 허용하지 않는 것을 추구 (특히 public)
- 함수에서 null 반환하지 않는 것을 추구 (특히 public)

### 제어문

- `switch`에 언제나 `default:` 케이스 포함
- `default:`가 실행될 일 없는 경우: `Debug.Fail()` 추가
- 모든 가정에 `Debug.Assert()` 삽입

### 예외 처리

- 외부 데이터 유효성은 외부/내부 경계에서 검증, 문제 시 내부 전달 전에 반환
- 내부 함수에서 예외 던지지 않으려 노력. 예외는 경계에서만 처리
- 예외 허용: `switch`의 `default:`에서 처리 안 된 enum 값 찾기 위한 예외

### 패턴

- 싱글턴 패턴 대신 정적(static) 클래스 사용
- `async void` 대신 `async Task` 사용. `async void`는 이벤트 핸들러만 허용

### 금지 사항

- null 병합 연산자 (C# 7.0) 사용 금지
- using 선언 (C# 8.0) 사용 금지 → using 문 사용

### 클래스 구성

- 클래스 내부 순서: 멤버 변수 → 프로퍼티 → 생성자 → 메서드
- 연관 있는 메서드끼리 그룹화. 멤버 변수도 동일
- 클래스는 각각 독립 소스 파일 (작은 클래스 몇 개는 한 파일 허용)
- 파일 이름 = 클래스 이름 (대소문자 일치)
- partial 클래스: `클래스명.세부항목.cs` → `Human.Head.cs`

## II. 소스 코드 포맷팅

- 탭: VS 기본값 또는 띄어쓰기 4칸
- 중괄호 `{`: 언제나 새로운 줄에서 열기
- 중괄호 안 코드가 한 줄이라도 반드시 중괄호 사용
- 한 줄에 변수 하나만 선언
