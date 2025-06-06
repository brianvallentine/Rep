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
    public class DB096_ACESSA_VGCOMPLCLIEMP_DB_SELECT_1_Query1 : QueryBasis<DB096_ACESSA_VGCOMPLCLIEMP_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT T1.DTA_FAT_ANUAL + 1 YEAR,
            T1.VLR_FAT_ANUAL,
            T1.DTA_CONSTITUICAO,
            T1.COD_CNAE_ATIVIDADE
            INTO :VG092-DTA-FAT-ANUAL,
            :VG092-VLR-FAT-ANUAL :N-NULL-2 ,
            :VG092-DTA-CONSTITUICAO :N-NULL-2 ,
            :VG092-COD-CNAE-ATIVIDADE :N-NULL-2
            FROM SEGUROS.VG_COMPL_CLI_EMP T1
            WHERE T1.COD_CLIENTE = :VG092-COD-CLIENTE
            AND T1.DTA_FAT_ANUAL =
            (SELECT MAX(T2.DTA_FAT_ANUAL)
            FROM SEGUROS.VG_COMPL_CLI_EMP T2
            WHERE T2.COD_CLIENTE = T1.COD_CLIENTE)
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT T1.DTA_FAT_ANUAL + 1 YEAR
							,
											T1.VLR_FAT_ANUAL
							,
											T1.DTA_CONSTITUICAO
							,
											T1.COD_CNAE_ATIVIDADE
											FROM SEGUROS.VG_COMPL_CLI_EMP T1
											WHERE T1.COD_CLIENTE = '{this.VG092_COD_CLIENTE}'
											AND T1.DTA_FAT_ANUAL =
											(SELECT MAX(T2.DTA_FAT_ANUAL)
											FROM SEGUROS.VG_COMPL_CLI_EMP T2
											WHERE T2.COD_CLIENTE = T1.COD_CLIENTE)";

            return query;
        }
        public string VG092_DTA_FAT_ANUAL { get; set; }
        public string VG092_VLR_FAT_ANUAL { get; set; }
        public string N_NULL_2 { get; set; }
        public string VG092_DTA_CONSTITUICAO { get; set; }
        public string VG092_COD_CNAE_ATIVIDADE { get; set; }
        public string VG092_COD_CLIENTE { get; set; }

        public static DB096_ACESSA_VGCOMPLCLIEMP_DB_SELECT_1_Query1 Execute(DB096_ACESSA_VGCOMPLCLIEMP_DB_SELECT_1_Query1 dB096_ACESSA_VGCOMPLCLIEMP_DB_SELECT_1_Query1)
        {
            var ths = dB096_ACESSA_VGCOMPLCLIEMP_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override DB096_ACESSA_VGCOMPLCLIEMP_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new DB096_ACESSA_VGCOMPLCLIEMP_DB_SELECT_1_Query1();
            var i = 0;
            dta.VG092_DTA_FAT_ANUAL = result[i++].Value?.ToString();
            dta.VG092_VLR_FAT_ANUAL = result[i++].Value?.ToString();
            dta.N_NULL_2 = string.IsNullOrWhiteSpace(dta.VG092_VLR_FAT_ANUAL) ? "-1" : "0";
            dta.VG092_DTA_CONSTITUICAO = result[i++].Value?.ToString();
            dta.VG092_COD_CNAE_ATIVIDADE = result[i++].Value?.ToString();
            return dta;
        }

    }
}