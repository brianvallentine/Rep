using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM8020B
{
    public class R1050_00_SELECT_GE368_DB_SELECT_1_Query1 : QueryBasis<R1050_00_SELECT_GE368_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_PESSOA ,
            NUM_OCORR_MOVTO,
            SEQ_ENTIDADE ,
            IND_ENTIDADE
            INTO :GE368-NUM-PESSOA ,
            :GE368-NUM-OCORR-MOVTO,
            :GE368-SEQ-ENTIDADE ,
            :GE368-IND-ENTIDADE
            FROM SEGUROS.GE_LEG_PESS_EVENTO
            WHERE NUM_OCORR_MOVTO = :GE368-NUM-OCORR-MOVTO
            AND IND_ENTIDADE = :GE368-IND-ENTIDADE
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_PESSOA 
							,
											NUM_OCORR_MOVTO
							,
											SEQ_ENTIDADE 
							,
											IND_ENTIDADE
											FROM SEGUROS.GE_LEG_PESS_EVENTO
											WHERE NUM_OCORR_MOVTO = '{this.GE368_NUM_OCORR_MOVTO}'
											AND IND_ENTIDADE = '{this.GE368_IND_ENTIDADE}'";

            return query;
        }
        public string GE368_NUM_PESSOA { get; set; }
        public string GE368_NUM_OCORR_MOVTO { get; set; }
        public string GE368_SEQ_ENTIDADE { get; set; }
        public string GE368_IND_ENTIDADE { get; set; }

        public static R1050_00_SELECT_GE368_DB_SELECT_1_Query1 Execute(R1050_00_SELECT_GE368_DB_SELECT_1_Query1 r1050_00_SELECT_GE368_DB_SELECT_1_Query1)
        {
            var ths = r1050_00_SELECT_GE368_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1050_00_SELECT_GE368_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1050_00_SELECT_GE368_DB_SELECT_1_Query1();
            var i = 0;
            dta.GE368_NUM_PESSOA = result[i++].Value?.ToString();
            dta.GE368_NUM_OCORR_MOVTO = result[i++].Value?.ToString();
            dta.GE368_SEQ_ENTIDADE = result[i++].Value?.ToString();
            dta.GE368_IND_ENTIDADE = result[i++].Value?.ToString();
            return dta;
        }

    }
}