using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmpresarial.DB2.VE2640B
{
    public class DB069_ACESSA_TAXAS_EMPRESARIAL_DB_SELECT_1_Query1 : QueryBasis<DB069_ACESSA_TAXAS_EMPRESARIAL_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT TAXA_VG ,
            TAXA_AP_MORACID ,
            TAXA_AP_INVPERM ,
            TAXA_AP_AMDS ,
            TAXA_AP_DH ,
            TAXA_AP_DIT
            INTO :TAXASEMP-TAXA-VG ,
            :TAXASEMP-TAXA-AP-MORACID ,
            :TAXASEMP-TAXA-AP-INVPERM ,
            :TAXASEMP-TAXA-AP-AMDS ,
            :TAXASEMP-TAXA-AP-DH ,
            :TAXASEMP-TAXA-AP-DIT
            FROM SEGUROS.TAXAS_EMPRESARIAL
            WHERE PERI_PAGAMENTO = 1
            AND DATA_INIVIGENCIA <= :TERMOADE-DATA-ADESAO
            AND DATA_TERVIGENCIA >= :TERMOADE-DATA-ADESAO
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT TAXA_VG 
							,
											TAXA_AP_MORACID 
							,
											TAXA_AP_INVPERM 
							,
											TAXA_AP_AMDS 
							,
											TAXA_AP_DH 
							,
											TAXA_AP_DIT
											FROM SEGUROS.TAXAS_EMPRESARIAL
											WHERE PERI_PAGAMENTO = 1
											AND DATA_INIVIGENCIA <= '{this.TERMOADE_DATA_ADESAO}'
											AND DATA_TERVIGENCIA >= '{this.TERMOADE_DATA_ADESAO}'";

            return query;
        }
        public string TAXASEMP_TAXA_VG { get; set; }
        public string TAXASEMP_TAXA_AP_MORACID { get; set; }
        public string TAXASEMP_TAXA_AP_INVPERM { get; set; }
        public string TAXASEMP_TAXA_AP_AMDS { get; set; }
        public string TAXASEMP_TAXA_AP_DH { get; set; }
        public string TAXASEMP_TAXA_AP_DIT { get; set; }
        public string TERMOADE_DATA_ADESAO { get; set; }

        public static DB069_ACESSA_TAXAS_EMPRESARIAL_DB_SELECT_1_Query1 Execute(DB069_ACESSA_TAXAS_EMPRESARIAL_DB_SELECT_1_Query1 dB069_ACESSA_TAXAS_EMPRESARIAL_DB_SELECT_1_Query1)
        {
            var ths = dB069_ACESSA_TAXAS_EMPRESARIAL_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override DB069_ACESSA_TAXAS_EMPRESARIAL_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new DB069_ACESSA_TAXAS_EMPRESARIAL_DB_SELECT_1_Query1();
            var i = 0;
            dta.TAXASEMP_TAXA_VG = result[i++].Value?.ToString();
            dta.TAXASEMP_TAXA_AP_MORACID = result[i++].Value?.ToString();
            dta.TAXASEMP_TAXA_AP_INVPERM = result[i++].Value?.ToString();
            dta.TAXASEMP_TAXA_AP_AMDS = result[i++].Value?.ToString();
            dta.TAXASEMP_TAXA_AP_DH = result[i++].Value?.ToString();
            dta.TAXASEMP_TAXA_AP_DIT = result[i++].Value?.ToString();
            return dta;
        }

    }
}