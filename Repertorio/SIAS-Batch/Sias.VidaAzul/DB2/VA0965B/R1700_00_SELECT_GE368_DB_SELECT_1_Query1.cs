using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0965B
{
    public class R1700_00_SELECT_GE368_DB_SELECT_1_Query1 : QueryBasis<R1700_00_SELECT_GE368_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT IND_ENTIDADE ,
            NUM_PESSOA ,
            SEQ_ENTIDADE
            INTO :GE368-IND-ENTIDADE ,
            :GE368-NUM-PESSOA ,
            :GE368-SEQ-ENTIDADE
            FROM SEGUROS.GE_LEG_PESS_EVENTO
            WHERE NUM_OCORR_MOVTO = :WHOST-NUM-OCORR-MOVTO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT IND_ENTIDADE 
							,
											NUM_PESSOA 
							,
											SEQ_ENTIDADE
											FROM SEGUROS.GE_LEG_PESS_EVENTO
											WHERE NUM_OCORR_MOVTO = '{this.WHOST_NUM_OCORR_MOVTO}'";

            return query;
        }
        public string GE368_IND_ENTIDADE { get; set; }
        public string GE368_NUM_PESSOA { get; set; }
        public string GE368_SEQ_ENTIDADE { get; set; }
        public string WHOST_NUM_OCORR_MOVTO { get; set; }

        public static R1700_00_SELECT_GE368_DB_SELECT_1_Query1 Execute(R1700_00_SELECT_GE368_DB_SELECT_1_Query1 r1700_00_SELECT_GE368_DB_SELECT_1_Query1)
        {
            var ths = r1700_00_SELECT_GE368_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1700_00_SELECT_GE368_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1700_00_SELECT_GE368_DB_SELECT_1_Query1();
            var i = 0;
            dta.GE368_IND_ENTIDADE = result[i++].Value?.ToString();
            dta.GE368_NUM_PESSOA = result[i++].Value?.ToString();
            dta.GE368_SEQ_ENTIDADE = result[i++].Value?.ToString();
            return dta;
        }

    }
}