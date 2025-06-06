using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0045B
{
    public class R3400_00_ACESSA_SINI_CONTRO_DB_SELECT_1_Query1 : QueryBasis<R3400_00_ACESSA_SINI_CONTRO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_FONTE,
            NUM_PROTOCOLO_SINI,
            DAC_PROTOCOLO_SINI,
            NUM_APOLICE,
            COD_SUBGRUPO,
            OCORR_HISTORICO,
            PEND_VISTORIA,
            PEND_RESSEGURO,
            SIT_REGISTRO,
            PEND_VIST_COMPL
            INTO :SINISCON-COD-FONTE,
            :SINISCON-NUM-PROTOCOLO-SINI,
            :SINISCON-DAC-PROTOCOLO-SINI,
            :SINISCON-NUM-APOLICE,
            :SINISCON-COD-SUBGRUPO,
            :SINISCON-OCORR-HISTORICO,
            :SINISCON-PEND-VISTORIA,
            :SINISCON-PEND-RESSEGURO,
            :SINISCON-SIT-REGISTRO,
            :SINISCON-PEND-VIST-COMPL
            FROM SEGUROS.SINISTRO_CONTROLE
            WHERE COD_FONTE = :SISINACO-COD-FONTE
            AND NUM_PROTOCOLO_SINI = :SISINACO-NUM-PROTOCOLO-SINI
            AND DAC_PROTOCOLO_SINI = :SISINACO-DAC-PROTOCOLO-SINI
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_FONTE
							,
											NUM_PROTOCOLO_SINI
							,
											DAC_PROTOCOLO_SINI
							,
											NUM_APOLICE
							,
											COD_SUBGRUPO
							,
											OCORR_HISTORICO
							,
											PEND_VISTORIA
							,
											PEND_RESSEGURO
							,
											SIT_REGISTRO
							,
											PEND_VIST_COMPL
											FROM SEGUROS.SINISTRO_CONTROLE
											WHERE COD_FONTE = '{this.SISINACO_COD_FONTE}'
											AND NUM_PROTOCOLO_SINI = '{this.SISINACO_NUM_PROTOCOLO_SINI}'
											AND DAC_PROTOCOLO_SINI = '{this.SISINACO_DAC_PROTOCOLO_SINI}'
											WITH UR";

            return query;
        }
        public string SINISCON_COD_FONTE { get; set; }
        public string SINISCON_NUM_PROTOCOLO_SINI { get; set; }
        public string SINISCON_DAC_PROTOCOLO_SINI { get; set; }
        public string SINISCON_NUM_APOLICE { get; set; }
        public string SINISCON_COD_SUBGRUPO { get; set; }
        public string SINISCON_OCORR_HISTORICO { get; set; }
        public string SINISCON_PEND_VISTORIA { get; set; }
        public string SINISCON_PEND_RESSEGURO { get; set; }
        public string SINISCON_SIT_REGISTRO { get; set; }
        public string SINISCON_PEND_VIST_COMPL { get; set; }
        public string SISINACO_NUM_PROTOCOLO_SINI { get; set; }
        public string SISINACO_DAC_PROTOCOLO_SINI { get; set; }
        public string SISINACO_COD_FONTE { get; set; }

        public static R3400_00_ACESSA_SINI_CONTRO_DB_SELECT_1_Query1 Execute(R3400_00_ACESSA_SINI_CONTRO_DB_SELECT_1_Query1 r3400_00_ACESSA_SINI_CONTRO_DB_SELECT_1_Query1)
        {
            var ths = r3400_00_ACESSA_SINI_CONTRO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R3400_00_ACESSA_SINI_CONTRO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R3400_00_ACESSA_SINI_CONTRO_DB_SELECT_1_Query1();
            var i = 0;
            dta.SINISCON_COD_FONTE = result[i++].Value?.ToString();
            dta.SINISCON_NUM_PROTOCOLO_SINI = result[i++].Value?.ToString();
            dta.SINISCON_DAC_PROTOCOLO_SINI = result[i++].Value?.ToString();
            dta.SINISCON_NUM_APOLICE = result[i++].Value?.ToString();
            dta.SINISCON_COD_SUBGRUPO = result[i++].Value?.ToString();
            dta.SINISCON_OCORR_HISTORICO = result[i++].Value?.ToString();
            dta.SINISCON_PEND_VISTORIA = result[i++].Value?.ToString();
            dta.SINISCON_PEND_RESSEGURO = result[i++].Value?.ToString();
            dta.SINISCON_SIT_REGISTRO = result[i++].Value?.ToString();
            dta.SINISCON_PEND_VIST_COMPL = result[i++].Value?.ToString();
            return dta;
        }

    }
}