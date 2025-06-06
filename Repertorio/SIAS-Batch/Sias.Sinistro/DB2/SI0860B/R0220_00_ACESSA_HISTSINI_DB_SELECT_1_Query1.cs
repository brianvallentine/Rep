using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0860B
{
    public class R0220_00_ACESSA_HISTSINI_DB_SELECT_1_Query1 : QueryBasis<R0220_00_ACESSA_HISTSINI_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(COUNT(*),0)
            INTO :HOST-HISTSINI
            FROM SEGUROS.SINISTRO_HISTORICO H,
            SEGUROS.GE_OPERACAO P
            WHERE H.NUM_APOL_SINISTRO = :SINBENCB-NUM-SINISTRO
            AND P.COD_OPERACAO = H.COD_OPERACAO
            AND P.IND_TIPO_FUNCAO = 'IN'
            AND P.IDE_SISTEMA = 'SI'
            AND P.FUNCAO_OPERACAO = 'IND'
            AND H.SIT_REGISTRO IN ( '0' , '1' )
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(COUNT(*)
							,0)
											FROM SEGUROS.SINISTRO_HISTORICO H
							,
											SEGUROS.GE_OPERACAO P
											WHERE H.NUM_APOL_SINISTRO = '{this.SINBENCB_NUM_SINISTRO}'
											AND P.COD_OPERACAO = H.COD_OPERACAO
											AND P.IND_TIPO_FUNCAO = 'IN'
											AND P.IDE_SISTEMA = 'SI'
											AND P.FUNCAO_OPERACAO = 'IND'
											AND H.SIT_REGISTRO IN ( '0' 
							, '1' )";

            return query;
        }
        public string HOST_HISTSINI { get; set; }
        public string SINBENCB_NUM_SINISTRO { get; set; }

        public static R0220_00_ACESSA_HISTSINI_DB_SELECT_1_Query1 Execute(R0220_00_ACESSA_HISTSINI_DB_SELECT_1_Query1 r0220_00_ACESSA_HISTSINI_DB_SELECT_1_Query1)
        {
            var ths = r0220_00_ACESSA_HISTSINI_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0220_00_ACESSA_HISTSINI_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0220_00_ACESSA_HISTSINI_DB_SELECT_1_Query1();
            var i = 0;
            dta.HOST_HISTSINI = result[i++].Value?.ToString();
            return dta;
        }

    }
}