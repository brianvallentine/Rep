using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Loterico.DB2.LT2118S
{
    public class R2610_00_VERIFICA_ALTERACAO_DB_SELECT_1_Query1 : QueryBasis<R2610_00_VERIFICA_ALTERACAO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_PRODUTO,
            COD_EXT_ESTIP,
            COD_EXT_SEGURADO,
            DATA_MOVIMENTO,
            HORA_MOVIMENTO,
            COD_MOVIMENTO,
            VAL_PREMIO,
            IND_TIPO_ENDOSSO
            INTO :LTMVPROP-COD-PRODUTO,
            :LTMVPROP-COD-EXT-ESTIP,
            :LTMVPROP-COD-EXT-SEGURADO,
            :LTMVPROP-DATA-MOVIMENTO,
            :LTMVPROP-HORA-MOVIMENTO,
            :LTMVPROP-COD-MOVIMENTO,
            :LTMVPROP-VAL-PREMIO,
            :LTMVPROP-IND-TIPO-ENDOSSO
            FROM SEGUROS.LT_MOV_PROPOSTA
            WHERE NUM_APOLICE = :LTMVPROP-NUM-APOLICE
            AND DT_INIVIG_PROPOSTA =
            :LTMVPROP-DT-INIVIG-PROPOSTA
            AND COD_MOVIMENTO IN ( 'A' , 'C' )
            AND SIT_MOVIMENTO = '1'
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_PRODUTO
							,
											COD_EXT_ESTIP
							,
											COD_EXT_SEGURADO
							,
											DATA_MOVIMENTO
							,
											HORA_MOVIMENTO
							,
											COD_MOVIMENTO
							,
											VAL_PREMIO
							,
											IND_TIPO_ENDOSSO
											FROM SEGUROS.LT_MOV_PROPOSTA
											WHERE NUM_APOLICE = '{this.LTMVPROP_NUM_APOLICE}'
											AND DT_INIVIG_PROPOSTA =
											'{this.LTMVPROP_DT_INIVIG_PROPOSTA}'
											AND COD_MOVIMENTO IN ( 'A' 
							, 'C' )
											AND SIT_MOVIMENTO = '1'
											WITH UR";

            return query;
        }
        public string LTMVPROP_COD_PRODUTO { get; set; }
        public string LTMVPROP_COD_EXT_ESTIP { get; set; }
        public string LTMVPROP_COD_EXT_SEGURADO { get; set; }
        public string LTMVPROP_DATA_MOVIMENTO { get; set; }
        public string LTMVPROP_HORA_MOVIMENTO { get; set; }
        public string LTMVPROP_COD_MOVIMENTO { get; set; }
        public string LTMVPROP_VAL_PREMIO { get; set; }
        public string LTMVPROP_IND_TIPO_ENDOSSO { get; set; }
        public string LTMVPROP_DT_INIVIG_PROPOSTA { get; set; }
        public string LTMVPROP_NUM_APOLICE { get; set; }

        public static R2610_00_VERIFICA_ALTERACAO_DB_SELECT_1_Query1 Execute(R2610_00_VERIFICA_ALTERACAO_DB_SELECT_1_Query1 r2610_00_VERIFICA_ALTERACAO_DB_SELECT_1_Query1)
        {
            var ths = r2610_00_VERIFICA_ALTERACAO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2610_00_VERIFICA_ALTERACAO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2610_00_VERIFICA_ALTERACAO_DB_SELECT_1_Query1();
            var i = 0;
            dta.LTMVPROP_COD_PRODUTO = result[i++].Value?.ToString();
            dta.LTMVPROP_COD_EXT_ESTIP = result[i++].Value?.ToString();
            dta.LTMVPROP_COD_EXT_SEGURADO = result[i++].Value?.ToString();
            dta.LTMVPROP_DATA_MOVIMENTO = result[i++].Value?.ToString();
            dta.LTMVPROP_HORA_MOVIMENTO = result[i++].Value?.ToString();
            dta.LTMVPROP_COD_MOVIMENTO = result[i++].Value?.ToString();
            dta.LTMVPROP_VAL_PREMIO = result[i++].Value?.ToString();
            dta.LTMVPROP_IND_TIPO_ENDOSSO = result[i++].Value?.ToString();
            return dta;
        }

    }
}