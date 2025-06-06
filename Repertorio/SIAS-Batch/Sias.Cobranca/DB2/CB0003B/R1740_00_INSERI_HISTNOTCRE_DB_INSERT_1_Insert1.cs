using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB0003B
{
    public class R1740_00_INSERI_HISTNOTCRE_DB_INSERT_1_Insert1 : QueryBasis<R1740_00_INSERI_HISTNOTCRE_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.V0HISTNOTCRE
            VALUES (:HNOTCRE-COD-EMP ,
            :V1MCOB-NUM-APOL ,
            :V1NOTA-NRENDOSR ,
            :V1NOTA-NRPARCELR ,
            :V1MCOB-NRENDOS ,
            :V1MCOB-NRPARCEL ,
            :HNOTCRE-OCORHIST ,
            :HNOTCRE-OPERACAO ,
            :V1SIST-DTMOVABE ,
            :HNOTCRE-HORAOPER ,
            :HNOTCRE-VALCREDR ,
            :HNOTCRE-VLPAGTO ,
            :V1NOTA-DTVENCTO ,
            :HNOTCRE-SITCONTB ,
            :V1MCOB-BANCO ,
            :V1MCOB-AGENCIA ,
            :HNOTCRE-NUMCHQ ,
            CURRENT TIMESTAMP)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0HISTNOTCRE VALUES ({FieldThreatment(this.HNOTCRE_COD_EMP)} , {FieldThreatment(this.V1MCOB_NUM_APOL)} , {FieldThreatment(this.V1NOTA_NRENDOSR)} , {FieldThreatment(this.V1NOTA_NRPARCELR)} , {FieldThreatment(this.V1MCOB_NRENDOS)} , {FieldThreatment(this.V1MCOB_NRPARCEL)} , {FieldThreatment(this.HNOTCRE_OCORHIST)} , {FieldThreatment(this.HNOTCRE_OPERACAO)} , {FieldThreatment(this.V1SIST_DTMOVABE)} , {FieldThreatment(this.HNOTCRE_HORAOPER)} , {FieldThreatment(this.HNOTCRE_VALCREDR)} , {FieldThreatment(this.HNOTCRE_VLPAGTO)} , {FieldThreatment(this.V1NOTA_DTVENCTO)} , {FieldThreatment(this.HNOTCRE_SITCONTB)} , {FieldThreatment(this.V1MCOB_BANCO)} , {FieldThreatment(this.V1MCOB_AGENCIA)} , {FieldThreatment(this.HNOTCRE_NUMCHQ)} , CURRENT TIMESTAMP)";

            return query;
        }
        public string HNOTCRE_COD_EMP { get; set; }
        public string V1MCOB_NUM_APOL { get; set; }
        public string V1NOTA_NRENDOSR { get; set; }
        public string V1NOTA_NRPARCELR { get; set; }
        public string V1MCOB_NRENDOS { get; set; }
        public string V1MCOB_NRPARCEL { get; set; }
        public string HNOTCRE_OCORHIST { get; set; }
        public string HNOTCRE_OPERACAO { get; set; }
        public string V1SIST_DTMOVABE { get; set; }
        public string HNOTCRE_HORAOPER { get; set; }
        public string HNOTCRE_VALCREDR { get; set; }
        public string HNOTCRE_VLPAGTO { get; set; }
        public string V1NOTA_DTVENCTO { get; set; }
        public string HNOTCRE_SITCONTB { get; set; }
        public string V1MCOB_BANCO { get; set; }
        public string V1MCOB_AGENCIA { get; set; }
        public string HNOTCRE_NUMCHQ { get; set; }

        public static void Execute(R1740_00_INSERI_HISTNOTCRE_DB_INSERT_1_Insert1 r1740_00_INSERI_HISTNOTCRE_DB_INSERT_1_Insert1)
        {
            var ths = r1740_00_INSERI_HISTNOTCRE_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1740_00_INSERI_HISTNOTCRE_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}