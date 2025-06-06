using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0130B
{
    public class M_0100_PROCESSA_PROPOSTA_DB_SELECT_2_Query1 : QueryBasis<M_0100_PROCESSA_PROPOSTA_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_ITEM,
            FAIXA,
            TAXA_VG,
            TAXA_AP_MORACID,
            TAXA_AP_INVPERM,
            TAXA_AP_AMDS,
            TAXA_AP_DH,
            TAXA_AP_DIT,
            SIT_REGISTRO,
            LOT_EMP_SEGURADO,
            OCORR_HISTORICO
            INTO :SEGURA-NUM-ITEM,
            :SEGURA-FAIXA,
            :SEGURA-TXVG,
            :SEGURA-TXAPMA,
            :SEGURA-TXAPIP,
            :SEGURA-TXAPAMDS,
            :SEGURA-TXAPDH,
            :SEGURA-TXAPDIT,
            :SEGURA-SIT-REGISTRO,
            :SEGURA-LOT-EMP-SEGURADO:WLOT-EMP-SEGURADO,
            :SEGURA-OCORHIST
            FROM SEGUROS.V0SEGURAVG
            WHERE NUM_APOLICE = :PROPVA-NUM-APOLICE
            AND COD_SUBGRUPO = :PROPVA-CODSUBES
            AND NUM_CERTIFICADO = :PROPVA-NRCERTIF
            AND TIPO_SEGURADO = '1'
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_ITEM
							,
											FAIXA
							,
											TAXA_VG
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
							,
											SIT_REGISTRO
							,
											LOT_EMP_SEGURADO
							,
											OCORR_HISTORICO
											FROM SEGUROS.V0SEGURAVG
											WHERE NUM_APOLICE = '{this.PROPVA_NUM_APOLICE}'
											AND COD_SUBGRUPO = '{this.PROPVA_CODSUBES}'
											AND NUM_CERTIFICADO = '{this.PROPVA_NRCERTIF}'
											AND TIPO_SEGURADO = '1'
											WITH UR";

            return query;
        }
        public string SEGURA_NUM_ITEM { get; set; }
        public string SEGURA_FAIXA { get; set; }
        public string SEGURA_TXVG { get; set; }
        public string SEGURA_TXAPMA { get; set; }
        public string SEGURA_TXAPIP { get; set; }
        public string SEGURA_TXAPAMDS { get; set; }
        public string SEGURA_TXAPDH { get; set; }
        public string SEGURA_TXAPDIT { get; set; }
        public string SEGURA_SIT_REGISTRO { get; set; }
        public string SEGURA_LOT_EMP_SEGURADO { get; set; }
        public string WLOT_EMP_SEGURADO { get; set; }
        public string SEGURA_OCORHIST { get; set; }
        public string PROPVA_NUM_APOLICE { get; set; }
        public string PROPVA_CODSUBES { get; set; }
        public string PROPVA_NRCERTIF { get; set; }

        public static M_0100_PROCESSA_PROPOSTA_DB_SELECT_2_Query1 Execute(M_0100_PROCESSA_PROPOSTA_DB_SELECT_2_Query1 m_0100_PROCESSA_PROPOSTA_DB_SELECT_2_Query1)
        {
            var ths = m_0100_PROCESSA_PROPOSTA_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_0100_PROCESSA_PROPOSTA_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_0100_PROCESSA_PROPOSTA_DB_SELECT_2_Query1();
            var i = 0;
            dta.SEGURA_NUM_ITEM = result[i++].Value?.ToString();
            dta.SEGURA_FAIXA = result[i++].Value?.ToString();
            dta.SEGURA_TXVG = result[i++].Value?.ToString();
            dta.SEGURA_TXAPMA = result[i++].Value?.ToString();
            dta.SEGURA_TXAPIP = result[i++].Value?.ToString();
            dta.SEGURA_TXAPAMDS = result[i++].Value?.ToString();
            dta.SEGURA_TXAPDH = result[i++].Value?.ToString();
            dta.SEGURA_TXAPDIT = result[i++].Value?.ToString();
            dta.SEGURA_SIT_REGISTRO = result[i++].Value?.ToString();
            dta.SEGURA_LOT_EMP_SEGURADO = result[i++].Value?.ToString();
            dta.WLOT_EMP_SEGURADO = string.IsNullOrWhiteSpace(dta.SEGURA_LOT_EMP_SEGURADO) ? "-1" : "0";
            dta.SEGURA_OCORHIST = result[i++].Value?.ToString();
            return dta;
        }

    }
}