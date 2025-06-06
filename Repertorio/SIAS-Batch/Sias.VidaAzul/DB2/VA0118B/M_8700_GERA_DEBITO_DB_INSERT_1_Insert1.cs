using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0118B
{
    public class M_8700_GERA_DEBITO_DB_INSERT_1_Insert1 : QueryBasis<M_8700_GERA_DEBITO_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.V0HISTCONTAVA
            (NRCERTIF ,
            NRPARCEL ,
            OCORRHISTCTA ,
            AGECTADEB ,
            OPRCTADEB ,
            NUMCTADEB ,
            DIGCTADEB ,
            DTVENCTO ,
            VLPRMTOT ,
            SITUACAO ,
            TIPLANC ,
            TIMESTAMP ,
            OCORHIST ,
            CODCONV ,
            NSAS ,
            NSL ,
            NSAC ,
            CODRET ,
            CODUSU ,
            NUM_CARTAO_CREDITO)
            VALUES (:PROPVA-NRCERTIF,
            1,
            1,
            :OPCAOP-AGECTADEB,
            :OPCAOP-OPRCTADEB,
            :OPCAOP-NUMCTADEB,
            :OPCAOP-DIGCTADEB,
            :HISTCB-DTVENCTO,
            :DESCON-VLPREMIO,
            '0' ,
            '1' ,
            CURRENT TIMESTAMP,
            0,
            :HOST-CODCONV,
            NULL,
            NULL,
            NULL,
            NULL,
            NULL,
            :OPCAOP-CARTAOCRED)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0HISTCONTAVA (NRCERTIF , NRPARCEL , OCORRHISTCTA , AGECTADEB , OPRCTADEB , NUMCTADEB , DIGCTADEB , DTVENCTO , VLPRMTOT , SITUACAO , TIPLANC , TIMESTAMP , OCORHIST , CODCONV , NSAS , NSL , NSAC , CODRET , CODUSU , NUM_CARTAO_CREDITO) VALUES ({FieldThreatment(this.PROPVA_NRCERTIF)}, 1, 1, {FieldThreatment(this.OPCAOP_AGECTADEB)}, {FieldThreatment(this.OPCAOP_OPRCTADEB)}, {FieldThreatment(this.OPCAOP_NUMCTADEB)}, {FieldThreatment(this.OPCAOP_DIGCTADEB)}, {FieldThreatment(this.HISTCB_DTVENCTO)}, {FieldThreatment(this.DESCON_VLPREMIO)}, '0' , '1' , CURRENT TIMESTAMP, 0, {FieldThreatment(this.HOST_CODCONV)}, NULL, NULL, NULL, NULL, NULL, {FieldThreatment(this.OPCAOP_CARTAOCRED)})";

            return query;
        }
        public string PROPVA_NRCERTIF { get; set; }
        public string OPCAOP_AGECTADEB { get; set; }
        public string OPCAOP_OPRCTADEB { get; set; }
        public string OPCAOP_NUMCTADEB { get; set; }
        public string OPCAOP_DIGCTADEB { get; set; }
        public string HISTCB_DTVENCTO { get; set; }
        public string DESCON_VLPREMIO { get; set; }
        public string HOST_CODCONV { get; set; }
        public string OPCAOP_CARTAOCRED { get; set; }

        public static void Execute(M_8700_GERA_DEBITO_DB_INSERT_1_Insert1 m_8700_GERA_DEBITO_DB_INSERT_1_Insert1)
        {
            var ths = m_8700_GERA_DEBITO_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_8700_GERA_DEBITO_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}