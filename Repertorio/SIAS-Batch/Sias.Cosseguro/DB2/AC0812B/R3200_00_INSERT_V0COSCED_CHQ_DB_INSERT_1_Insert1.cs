using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cosseguro.DB2.AC0812B
{
    public class R3200_00_INSERT_V0COSCED_CHQ_DB_INSERT_1_Insert1 : QueryBasis<R3200_00_INSERT_V0COSCED_CHQ_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL INSERT
            INTO SEGUROS.V0COSCED_CHEQUE
            VALUES (:V0CCHQ-COD-EMPR ,
            :V0CCHQ-CONGENER ,
            :V0CCHQ-DTMOVTO-AC ,
            :V0CCHQ-CODUSU-AC ,
            :V0CCHQ-DTLIBERA ,
            0,
            0,
            :V0CCHQ-VLPREMIO ,
            :V0CCHQ-VLRDESCON ,
            :V0CCHQ-VLRADIFRA ,
            :V0CCHQ-VLRCOMIS ,
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            :V0CCHQ-OUTRDEBIT,
            0,
            :V0CCHQ-VLRSLDANT,
            ' ' ,
            :V0CCHQ-COD-MOEDA:VIND-CODUNIMO,
            :V0CCHQ-DTMOVTO-FI:VIND-DTMOVTO-FI,
            :V0CCHQ-CODUSU-FI:VIND-COD-USU-FI,
            :V0CCHQ-DTCORRECAO:VIND-DTCORRECAO,
            CURRENT TIMESTAMP)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0COSCED_CHEQUE VALUES ({FieldThreatment(this.V0CCHQ_COD_EMPR)} , {FieldThreatment(this.V0CCHQ_CONGENER)} , {FieldThreatment(this.V0CCHQ_DTMOVTO_AC)} , {FieldThreatment(this.V0CCHQ_CODUSU_AC)} , {FieldThreatment(this.V0CCHQ_DTLIBERA)} , 0, 0, {FieldThreatment(this.V0CCHQ_VLPREMIO)} , {FieldThreatment(this.V0CCHQ_VLRDESCON)} , {FieldThreatment(this.V0CCHQ_VLRADIFRA)} , {FieldThreatment(this.V0CCHQ_VLRCOMIS)} , 0, 0, 0, 0, 0, 0, 0, 0, 0, {FieldThreatment(this.V0CCHQ_OUTRDEBIT)}, 0, {FieldThreatment(this.V0CCHQ_VLRSLDANT)}, ' ' ,  {FieldThreatment((this.VIND_CODUNIMO?.ToInt() == -1 ? null : this.V0CCHQ_COD_MOEDA))},  {FieldThreatment((this.VIND_DTMOVTO_FI?.ToInt() == -1 ? null : this.V0CCHQ_DTMOVTO_FI))},  {FieldThreatment((this.VIND_COD_USU_FI?.ToInt() == -1 ? null : this.V0CCHQ_CODUSU_FI))},  {FieldThreatment((this.VIND_DTCORRECAO?.ToInt() == -1 ? null : this.V0CCHQ_DTCORRECAO))}, CURRENT TIMESTAMP)";

            return query;
        }
        public string V0CCHQ_COD_EMPR { get; set; }
        public string V0CCHQ_CONGENER { get; set; }
        public string V0CCHQ_DTMOVTO_AC { get; set; }
        public string V0CCHQ_CODUSU_AC { get; set; }
        public string V0CCHQ_DTLIBERA { get; set; }
        public string V0CCHQ_VLPREMIO { get; set; }
        public string V0CCHQ_VLRDESCON { get; set; }
        public string V0CCHQ_VLRADIFRA { get; set; }
        public string V0CCHQ_VLRCOMIS { get; set; }
        public string V0CCHQ_OUTRDEBIT { get; set; }
        public string V0CCHQ_VLRSLDANT { get; set; }
        public string V0CCHQ_COD_MOEDA { get; set; }
        public string VIND_CODUNIMO { get; set; }
        public string V0CCHQ_DTMOVTO_FI { get; set; }
        public string VIND_DTMOVTO_FI { get; set; }
        public string V0CCHQ_CODUSU_FI { get; set; }
        public string VIND_COD_USU_FI { get; set; }
        public string V0CCHQ_DTCORRECAO { get; set; }
        public string VIND_DTCORRECAO { get; set; }

        public static void Execute(R3200_00_INSERT_V0COSCED_CHQ_DB_INSERT_1_Insert1 r3200_00_INSERT_V0COSCED_CHQ_DB_INSERT_1_Insert1)
        {
            var ths = r3200_00_INSERT_V0COSCED_CHQ_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R3200_00_INSERT_V0COSCED_CHQ_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}