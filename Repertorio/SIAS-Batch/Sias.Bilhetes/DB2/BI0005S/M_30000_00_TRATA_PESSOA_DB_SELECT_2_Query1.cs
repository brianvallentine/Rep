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
    public class M_30000_00_TRATA_PESSOA_DB_SELECT_2_Query1 : QueryBasis<M_30000_00_TRATA_PESSOA_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT CPF ,
            DATA_NASCIMENTO ,
            SEXO ,
            ESTADO_CIVIL ,
            NUM_IDENTIDADE ,
            ORGAO_EXPEDIDOR ,
            UF_EXPEDIDORA ,
            DATA_EXPEDICAO ,
            COD_CBO ,
            TIPO_IDENT_SIVPF
            INTO :BI0005L-S-CPF ,
            :BI0005L-S-DATA-NASC ,
            :BI0005L-S-SEXO ,
            :BI0005L-S-ESTADO-CIVIL ,
            :BI0005L-S-NUM-IDENT ,
            :BI0005L-S-ORGAO-EXPED ,
            :BI0005L-S-UF-EXPEDIDORA ,
            :BI0005L-S-DATA-EXPED :VIND-FILLER ,
            :BI0005L-S-COD-CBO ,
            :BI0005L-S-TIP-IDE-SIVPF
            FROM SEGUROS.PESSOA_FISICA
            WHERE COD_PESSOA = :BI0005L-E-COD-PESSOA
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT CPF 
							,
											DATA_NASCIMENTO 
							,
											SEXO 
							,
											ESTADO_CIVIL 
							,
											NUM_IDENTIDADE 
							,
											ORGAO_EXPEDIDOR 
							,
											UF_EXPEDIDORA 
							,
											DATA_EXPEDICAO 
							,
											COD_CBO 
							,
											TIPO_IDENT_SIVPF
											FROM SEGUROS.PESSOA_FISICA
											WHERE COD_PESSOA = '{this.BI0005L_E_COD_PESSOA}'
											WITH UR";

            return query;
        }
        public string BI0005L_S_CPF { get; set; }
        public string BI0005L_S_DATA_NASC { get; set; }
        public string BI0005L_S_SEXO { get; set; }
        public string BI0005L_S_ESTADO_CIVIL { get; set; }
        public string BI0005L_S_NUM_IDENT { get; set; }
        public string BI0005L_S_ORGAO_EXPED { get; set; }
        public string BI0005L_S_UF_EXPEDIDORA { get; set; }
        public string BI0005L_S_DATA_EXPED { get; set; }
        public string VIND_FILLER { get; set; }
        public string BI0005L_S_COD_CBO { get; set; }
        public string BI0005L_S_TIP_IDE_SIVPF { get; set; }
        public string BI0005L_E_COD_PESSOA { get; set; }

        public static M_30000_00_TRATA_PESSOA_DB_SELECT_2_Query1 Execute(M_30000_00_TRATA_PESSOA_DB_SELECT_2_Query1 m_30000_00_TRATA_PESSOA_DB_SELECT_2_Query1)
        {
            var ths = m_30000_00_TRATA_PESSOA_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_30000_00_TRATA_PESSOA_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_30000_00_TRATA_PESSOA_DB_SELECT_2_Query1();
            var i = 0;
            dta.BI0005L_S_CPF = result[i++].Value?.ToString();
            dta.BI0005L_S_DATA_NASC = result[i++].Value?.ToString();
            dta.BI0005L_S_SEXO = result[i++].Value?.ToString();
            dta.BI0005L_S_ESTADO_CIVIL = result[i++].Value?.ToString();
            dta.BI0005L_S_NUM_IDENT = result[i++].Value?.ToString();
            dta.BI0005L_S_ORGAO_EXPED = result[i++].Value?.ToString();
            dta.BI0005L_S_UF_EXPEDIDORA = result[i++].Value?.ToString();
            dta.BI0005L_S_DATA_EXPED = result[i++].Value?.ToString();
            dta.VIND_FILLER = string.IsNullOrWhiteSpace(dta.BI0005L_S_DATA_EXPED) ? "-1" : "0";
            dta.BI0005L_S_COD_CBO = result[i++].Value?.ToString();
            dta.BI0005L_S_TIP_IDE_SIVPF = result[i++].Value?.ToString();
            return dta;
        }

    }
}