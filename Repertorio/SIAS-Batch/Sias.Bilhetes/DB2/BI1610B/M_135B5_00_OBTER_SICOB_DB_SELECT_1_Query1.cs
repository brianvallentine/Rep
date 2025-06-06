using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI1610B
{
    public class M_135B5_00_OBTER_SICOB_DB_SELECT_1_Query1 : QueryBasis<M_135B5_00_OBTER_SICOB_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(NUM_SICOB,0)
            DATA_OPERACAO,
            DATA_QUITACAO,
            VAL_RCAP
            INTO :DCLCONVERSAO-SICOB.NUM-SICOB ,
            :DCLCONVERSAO-SICOB.DATA-OPERACAO,
            :DCLCONVERSAO-SICOB.DATA-QUITACAO,
            :DCLCONVERSAO-SICOB.VAL-RCAP
            FROM SEGUROS.CONVERSAO_SICOB
            WHERE NUM_PROPOSTA_SIVPF =
            :DCLCONVERSAO-SICOB.NUM-PROPOSTA-SIVPF
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT VALUE(NUM_SICOB
							,0)
											DATA_OPERACAO
							,
											DATA_QUITACAO
							,
											VAL_RCAP
											FROM SEGUROS.CONVERSAO_SICOB
											WHERE NUM_PROPOSTA_SIVPF =
											'{this.NUM_PROPOSTA_SIVPF}'
											WITH UR";

            return query;
        }
        public string NUM_SICOB { get; set; }
        public string DATA_OPERACAO { get; set; }
        public string DATA_QUITACAO { get; set; }
        public string VAL_RCAP { get; set; }
        public string NUM_PROPOSTA_SIVPF { get; set; }

        public static M_135B5_00_OBTER_SICOB_DB_SELECT_1_Query1 Execute(M_135B5_00_OBTER_SICOB_DB_SELECT_1_Query1 m_135B5_00_OBTER_SICOB_DB_SELECT_1_Query1)
        {
            var ths = m_135B5_00_OBTER_SICOB_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_135B5_00_OBTER_SICOB_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_135B5_00_OBTER_SICOB_DB_SELECT_1_Query1();
            var i = 0;
            dta.NUM_SICOB = result[i++].Value?.ToString();
            dta.DATA_OPERACAO = result[i++].Value?.ToString();
            dta.DATA_QUITACAO = result[i++].Value?.ToString();
            dta.VAL_RCAP = result[i++].Value?.ToString();
            return dta;
        }

    }
}