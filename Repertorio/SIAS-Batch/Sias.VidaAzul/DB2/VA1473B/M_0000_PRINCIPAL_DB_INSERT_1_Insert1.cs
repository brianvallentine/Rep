using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA1473B
{
    public class M_0000_PRINCIPAL_DB_INSERT_1_Insert1 : QueryBasis<M_0000_PRINCIPAL_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.CONT_ARQUIVOS_EA
            VALUES (:CONARQEA-NSAS,
            :CONARQEA-ANO-REFERENCIA,
            :CONARQEA-NUM-ARQUIVO,
            CURRENT DATE,
            :CONARQEA-NUM-REGISTROS,
            :CONARQEA-NUM-INCLUSOES,
            :CONARQEA-NUM-ALTERACOES,
            :CONARQEA-NUM-EXCLUSOES,
            'VA1473B' ,
            CURRENT TIMESTAMP)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.CONT_ARQUIVOS_EA VALUES ({FieldThreatment(this.CONARQEA_NSAS)}, {FieldThreatment(this.CONARQEA_ANO_REFERENCIA)}, {FieldThreatment(this.CONARQEA_NUM_ARQUIVO)}, CURRENT DATE, {FieldThreatment(this.CONARQEA_NUM_REGISTROS)}, {FieldThreatment(this.CONARQEA_NUM_INCLUSOES)}, {FieldThreatment(this.CONARQEA_NUM_ALTERACOES)}, {FieldThreatment(this.CONARQEA_NUM_EXCLUSOES)}, 'VA1473B' , CURRENT TIMESTAMP)";

            return query;
        }
        public string CONARQEA_NSAS { get; set; }
        public string CONARQEA_ANO_REFERENCIA { get; set; }
        public string CONARQEA_NUM_ARQUIVO { get; set; }
        public string CONARQEA_NUM_REGISTROS { get; set; }
        public string CONARQEA_NUM_INCLUSOES { get; set; }
        public string CONARQEA_NUM_ALTERACOES { get; set; }
        public string CONARQEA_NUM_EXCLUSOES { get; set; }

        public static void Execute(M_0000_PRINCIPAL_DB_INSERT_1_Insert1 m_0000_PRINCIPAL_DB_INSERT_1_Insert1)
        {
            var ths = m_0000_PRINCIPAL_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_0000_PRINCIPAL_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}