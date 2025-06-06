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
    public class M_90000_00_ENDERECO_FIS_DB_SELECT_2_Query1 : QueryBasis<M_90000_00_ENDERECO_FIS_DB_SELECT_2_Query1>
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
            INTO :BI0005L-S-ENDERECO-R ,
            :BI0005L-S-OCC-END-R ,
            :BI0005L-S-TIPO-ENDER-R ,
            :BI0005L-S-COMPL-ENDER-R :VIND-FILLER ,
            :BI0005L-S-BAIRRO-R ,
            :BI0005L-S-CEP-R ,
            :BI0005L-S-CIDADE-R ,
            :BI0005L-S-SIGLA-UF-R ,
            :BI0005L-S-SIT-ENDER-R
            FROM SEGUROS.PESSOA_ENDERECO
            WHERE COD_PESSOA = :BI0005L-E-COD-PESSOA
            AND TIPO_ENDER = 001
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
											AND TIPO_ENDER = 001
											AND OCORR_ENDERECO = '{this.WS_MAX_OCO_END}'
											WITH UR";

            return query;
        }
        public string BI0005L_S_ENDERECO_R { get; set; }
        public string BI0005L_S_OCC_END_R { get; set; }
        public string BI0005L_S_TIPO_ENDER_R { get; set; }
        public string BI0005L_S_COMPL_ENDER_R { get; set; }
        public string VIND_FILLER { get; set; }
        public string BI0005L_S_BAIRRO_R { get; set; }
        public string BI0005L_S_CEP_R { get; set; }
        public string BI0005L_S_CIDADE_R { get; set; }
        public string BI0005L_S_SIGLA_UF_R { get; set; }
        public string BI0005L_S_SIT_ENDER_R { get; set; }
        public string BI0005L_E_COD_PESSOA { get; set; }
        public string WS_MAX_OCO_END { get; set; }

        public static M_90000_00_ENDERECO_FIS_DB_SELECT_2_Query1 Execute(M_90000_00_ENDERECO_FIS_DB_SELECT_2_Query1 m_90000_00_ENDERECO_FIS_DB_SELECT_2_Query1)
        {
            var ths = m_90000_00_ENDERECO_FIS_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_90000_00_ENDERECO_FIS_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_90000_00_ENDERECO_FIS_DB_SELECT_2_Query1();
            var i = 0;
            dta.BI0005L_S_ENDERECO_R = result[i++].Value?.ToString();
            dta.BI0005L_S_OCC_END_R = result[i++].Value?.ToString();
            dta.BI0005L_S_TIPO_ENDER_R = result[i++].Value?.ToString();
            dta.BI0005L_S_COMPL_ENDER_R = result[i++].Value?.ToString();
            dta.VIND_FILLER = string.IsNullOrWhiteSpace(dta.BI0005L_S_COMPL_ENDER_R) ? "-1" : "0";
            dta.BI0005L_S_BAIRRO_R = result[i++].Value?.ToString();
            dta.BI0005L_S_CEP_R = result[i++].Value?.ToString();
            dta.BI0005L_S_CIDADE_R = result[i++].Value?.ToString();
            dta.BI0005L_S_SIGLA_UF_R = result[i++].Value?.ToString();
            dta.BI0005L_S_SIT_ENDER_R = result[i++].Value?.ToString();
            return dta;
        }

    }
}