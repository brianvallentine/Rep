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
    public class R0350_00_SELECT_GE366_DB_SELECT_1_Query1 : QueryBasis<R0350_00_SELECT_GE366_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_OCORR_MOVTO,
            COD_EVENTO ,
            IDE_SISTEMA ,
            IND_ESTRUTURA ,
            IND_ORIGEM_FUNC,
            IND_EVENTO
            INTO :GE366-NUM-OCORR-MOVTO,
            :GE366-COD-EVENTO ,
            :GE366-IDE-SISTEMA ,
            :GE366-IND-ESTRUTURA ,
            :GE366-IND-ORIGEM-FUNC,
            :GE366-IND-EVENTO
            FROM SEGUROS.GE_MOVIMENTO
            WHERE NUM_OCORR_MOVTO = :GE366-NUM-OCORR-MOVTO
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_OCORR_MOVTO
							,
											COD_EVENTO 
							,
											IDE_SISTEMA 
							,
											IND_ESTRUTURA 
							,
											IND_ORIGEM_FUNC
							,
											IND_EVENTO
											FROM SEGUROS.GE_MOVIMENTO
											WHERE NUM_OCORR_MOVTO = '{this.GE366_NUM_OCORR_MOVTO}'
											WITH UR";

            return query;
        }
        public string GE366_NUM_OCORR_MOVTO { get; set; }
        public string GE366_COD_EVENTO { get; set; }
        public string GE366_IDE_SISTEMA { get; set; }
        public string GE366_IND_ESTRUTURA { get; set; }
        public string GE366_IND_ORIGEM_FUNC { get; set; }
        public string GE366_IND_EVENTO { get; set; }

        public static R0350_00_SELECT_GE366_DB_SELECT_1_Query1 Execute(R0350_00_SELECT_GE366_DB_SELECT_1_Query1 r0350_00_SELECT_GE366_DB_SELECT_1_Query1)
        {
            var ths = r0350_00_SELECT_GE366_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0350_00_SELECT_GE366_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0350_00_SELECT_GE366_DB_SELECT_1_Query1();
            var i = 0;
            dta.GE366_NUM_OCORR_MOVTO = result[i++].Value?.ToString();
            dta.GE366_COD_EVENTO = result[i++].Value?.ToString();
            dta.GE366_IDE_SISTEMA = result[i++].Value?.ToString();
            dta.GE366_IND_ESTRUTURA = result[i++].Value?.ToString();
            dta.GE366_IND_ORIGEM_FUNC = result[i++].Value?.ToString();
            dta.GE366_IND_EVENTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}