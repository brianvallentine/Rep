using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA1471B
{
    public class M_0100_PROCESSA_PROPOSTA_DB_SELECT_1_Query1 : QueryBasis<M_0100_PROCESSA_PROPOSTA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT B.NUM_PROPOSTA_SIVPF ,
            B.COD_PRODUTO_SIVPF
            INTO :CONVERSI-NUM-PROPOSTA-SIVPF ,
            :CONVERSI-COD-PRODUTO-SIVPF
            FROM SEGUROS.BILHETE A,
            SEGUROS.CONVERSAO_SICOB B
            WHERE A.NUM_BILHETE = :PROPOVA-NUM-CERTIFICADO
            AND A.NUM_BILHETE = B.NUM_SICOB
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT B.NUM_PROPOSTA_SIVPF 
							,
											B.COD_PRODUTO_SIVPF
											FROM SEGUROS.BILHETE A
							,
											SEGUROS.CONVERSAO_SICOB B
											WHERE A.NUM_BILHETE = '{this.PROPOVA_NUM_CERTIFICADO}'
											AND A.NUM_BILHETE = B.NUM_SICOB";

            return query;
        }
        public string CONVERSI_NUM_PROPOSTA_SIVPF { get; set; }
        public string CONVERSI_COD_PRODUTO_SIVPF { get; set; }
        public string PROPOVA_NUM_CERTIFICADO { get; set; }

        public static M_0100_PROCESSA_PROPOSTA_DB_SELECT_1_Query1 Execute(M_0100_PROCESSA_PROPOSTA_DB_SELECT_1_Query1 m_0100_PROCESSA_PROPOSTA_DB_SELECT_1_Query1)
        {
            var ths = m_0100_PROCESSA_PROPOSTA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_0100_PROCESSA_PROPOSTA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_0100_PROCESSA_PROPOSTA_DB_SELECT_1_Query1();
            var i = 0;
            dta.CONVERSI_NUM_PROPOSTA_SIVPF = result[i++].Value?.ToString();
            dta.CONVERSI_COD_PRODUTO_SIVPF = result[i++].Value?.ToString();
            return dta;
        }

    }
}