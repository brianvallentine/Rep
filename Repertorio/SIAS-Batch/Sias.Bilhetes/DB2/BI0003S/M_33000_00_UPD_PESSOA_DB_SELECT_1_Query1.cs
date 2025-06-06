using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI0003S
{
    public class M_33000_00_UPD_PESSOA_DB_SELECT_1_Query1 : QueryBasis<M_33000_00_UPD_PESSOA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_IDENTIDADE ,
            ORGAO_EXPEDIDOR ,
            UF_EXPEDIDORA ,
            DATA_EXPEDICAO
            INTO :DCLPESSOA-FISICA.NUM-IDENTIDADE:VIND-NULL01,
            :DCLPESSOA-FISICA.ORGAO-EXPEDIDOR:VIND-NULL02,
            :DCLPESSOA-FISICA.UF-EXPEDIDORA:VIND-UNEXPEDI,
            :DCLPESSOA-FISICA.DATA-EXPEDICAO:VIND-DTEXPEDI
            FROM SEGUROS.PESSOA_FISICA
            WHERE COD_PESSOA = :WS-COD-PES-ATU
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT NUM_IDENTIDADE 
							,
											ORGAO_EXPEDIDOR 
							,
											UF_EXPEDIDORA 
							,
											DATA_EXPEDICAO
											FROM SEGUROS.PESSOA_FISICA
											WHERE COD_PESSOA = '{this.WS_COD_PES_ATU}'
											WITH UR";

            return query;
        }
        public string NUM_IDENTIDADE { get; set; }
        public string VIND_NULL01 { get; set; }
        public string ORGAO_EXPEDIDOR { get; set; }
        public string VIND_NULL02 { get; set; }
        public string UF_EXPEDIDORA { get; set; }
        public string VIND_UNEXPEDI { get; set; }
        public string DATA_EXPEDICAO { get; set; }
        public string VIND_DTEXPEDI { get; set; }
        public string WS_COD_PES_ATU { get; set; }

        public static M_33000_00_UPD_PESSOA_DB_SELECT_1_Query1 Execute(M_33000_00_UPD_PESSOA_DB_SELECT_1_Query1 m_33000_00_UPD_PESSOA_DB_SELECT_1_Query1)
        {
            var ths = m_33000_00_UPD_PESSOA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_33000_00_UPD_PESSOA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_33000_00_UPD_PESSOA_DB_SELECT_1_Query1();
            var i = 0;
            dta.NUM_IDENTIDADE = result[i++].Value?.ToString();
            dta.VIND_NULL01 = string.IsNullOrWhiteSpace(dta.NUM_IDENTIDADE) ? "-1" : "0";
            dta.ORGAO_EXPEDIDOR = result[i++].Value?.ToString();
            dta.VIND_NULL02 = string.IsNullOrWhiteSpace(dta.ORGAO_EXPEDIDOR) ? "-1" : "0";
            dta.UF_EXPEDIDORA = result[i++].Value?.ToString();
            dta.VIND_UNEXPEDI = string.IsNullOrWhiteSpace(dta.UF_EXPEDIDORA) ? "-1" : "0";
            dta.DATA_EXPEDICAO = result[i++].Value?.ToString();
            dta.VIND_DTEXPEDI = string.IsNullOrWhiteSpace(dta.DATA_EXPEDICAO) ? "-1" : "0";
            return dta;
        }

    }
}