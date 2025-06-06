using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI0005S
{
    public class B0000_00_ENDERECO_JUR_DB_SELECT_2_Query1 : QueryBasis<B0000_00_ENDERECO_JUR_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT ENDERECO ,
            OCORR_ENDERECO ,
            TIPO_ENDER ,
            COMPL_ENDER ,
            BAIRRO ,
            CEP ,
            CIDADE ,
            SIGLA_UF ,
            SITUACAO_ENDERECO
            INTO :BI0005L-S-ENDERECO-C ,
            :BI0005L-S-OCC-END-C ,
            :BI0005L-S-TIPO-ENDER-C ,
            :BI0005L-S-COMPL-ENDER-C :VIND-FILLER ,
            :BI0005L-S-BAIRRO-C ,
            :BI0005L-S-CEP-C ,
            :BI0005L-S-CIDADE-C ,
            :BI0005L-S-SIGLA-UF-C ,
            :BI0005L-S-SIT-ENDER-C
            FROM SEGUROS.PESSOA_ENDERECO
            WHERE COD_PESSOA = :BI0005L-E-COD-PESSOA
            AND TIPO_ENDER = 002
            AND OCORR_ENDERECO = :WS-MAX-OCO-END
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT ENDERECO 
							,
											OCORR_ENDERECO 
							,
											TIPO_ENDER 
							,
											COMPL_ENDER 
							,
											BAIRRO 
							,
											CEP 
							,
											CIDADE 
							,
											SIGLA_UF 
							,
											SITUACAO_ENDERECO
											FROM SEGUROS.PESSOA_ENDERECO
											WHERE COD_PESSOA = '{this.BI0005L_E_COD_PESSOA}'
											AND TIPO_ENDER = 002
											AND OCORR_ENDERECO = '{this.WS_MAX_OCO_END}'
											WITH UR";

            return query;
        }
        public string BI0005L_S_ENDERECO_C { get; set; }
        public string BI0005L_S_OCC_END_C { get; set; }
        public string BI0005L_S_TIPO_ENDER_C { get; set; }
        public string BI0005L_S_COMPL_ENDER_C { get; set; }
        public string VIND_FILLER { get; set; }
        public string BI0005L_S_BAIRRO_C { get; set; }
        public string BI0005L_S_CEP_C { get; set; }
        public string BI0005L_S_CIDADE_C { get; set; }
        public string BI0005L_S_SIGLA_UF_C { get; set; }
        public string BI0005L_S_SIT_ENDER_C { get; set; }
        public string BI0005L_E_COD_PESSOA { get; set; }
        public string WS_MAX_OCO_END { get; set; }

        public static B0000_00_ENDERECO_JUR_DB_SELECT_2_Query1 Execute(B0000_00_ENDERECO_JUR_DB_SELECT_2_Query1 b0000_00_ENDERECO_JUR_DB_SELECT_2_Query1)
        {
            var ths = b0000_00_ENDERECO_JUR_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override B0000_00_ENDERECO_JUR_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new B0000_00_ENDERECO_JUR_DB_SELECT_2_Query1();
            var i = 0;
            dta.BI0005L_S_ENDERECO_C = result[i++].Value?.ToString();
            dta.BI0005L_S_OCC_END_C = result[i++].Value?.ToString();
            dta.BI0005L_S_TIPO_ENDER_C = result[i++].Value?.ToString();
            dta.BI0005L_S_COMPL_ENDER_C = result[i++].Value?.ToString();
            dta.VIND_FILLER = string.IsNullOrWhiteSpace(dta.BI0005L_S_COMPL_ENDER_C) ? "-1" : "0";
            dta.BI0005L_S_BAIRRO_C = result[i++].Value?.ToString();
            dta.BI0005L_S_CEP_C = result[i++].Value?.ToString();
            dta.BI0005L_S_CIDADE_C = result[i++].Value?.ToString();
            dta.BI0005L_S_SIGLA_UF_C = result[i++].Value?.ToString();
            dta.BI0005L_S_SIT_ENDER_C = result[i++].Value?.ToString();
            return dta;
        }

    }
}