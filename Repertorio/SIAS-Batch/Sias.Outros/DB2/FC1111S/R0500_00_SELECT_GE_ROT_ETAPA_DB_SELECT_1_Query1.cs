using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Outros.DB2.FC1111S
{
    public class R0500_00_SELECT_GE_ROT_ETAPA_DB_SELECT_1_Query1 : QueryBasis<R0500_00_SELECT_GE_ROT_ETAPA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NOM_ROTINA,
            SEQ_ETAPA,
            DTH_INI_VIGENCIA,
            IND_TIPO_ETAPA,
            NOM_PROGRAMA,
            STA_ETAPA,
            QTD_EXEC_ETAPA
            INTO :GE386-NOM-ROTINA,
            :GE386-SEQ-ETAPA,
            :GE386-DTH-INI-VIGENCIA,
            :GE386-IND-TIPO-ETAPA,
            :GE386-NOM-PROGRAMA:VIND-NOM-PROGRAMA,
            :GE386-STA-ETAPA,
            :GE386-QTD-EXEC-ETAPA
            FROM SEGUROS.GE_ROTINA_ETAPA
            WHERE NOM_ROTINA = :GE386-NOM-ROTINA
            AND SEQ_ETAPA = :GE386-SEQ-ETAPA
            AND DTH_FIM_VIGENCIA IS NULL
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NOM_ROTINA
							,
											SEQ_ETAPA
							,
											DTH_INI_VIGENCIA
							,
											IND_TIPO_ETAPA
							,
											NOM_PROGRAMA
							,
											STA_ETAPA
							,
											QTD_EXEC_ETAPA
											FROM SEGUROS.GE_ROTINA_ETAPA
											WHERE NOM_ROTINA = '{this.GE386_NOM_ROTINA}'
											AND SEQ_ETAPA = '{this.GE386_SEQ_ETAPA}'
											AND DTH_FIM_VIGENCIA IS NULL";

            return query;
        }
        public string GE386_NOM_ROTINA { get; set; }
        public string GE386_SEQ_ETAPA { get; set; }
        public string GE386_DTH_INI_VIGENCIA { get; set; }
        public string GE386_IND_TIPO_ETAPA { get; set; }
        public string GE386_NOM_PROGRAMA { get; set; }
        public string VIND_NOM_PROGRAMA { get; set; }
        public string GE386_STA_ETAPA { get; set; }
        public string GE386_QTD_EXEC_ETAPA { get; set; }

        public static R0500_00_SELECT_GE_ROT_ETAPA_DB_SELECT_1_Query1 Execute(R0500_00_SELECT_GE_ROT_ETAPA_DB_SELECT_1_Query1 r0500_00_SELECT_GE_ROT_ETAPA_DB_SELECT_1_Query1)
        {
            var ths = r0500_00_SELECT_GE_ROT_ETAPA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0500_00_SELECT_GE_ROT_ETAPA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0500_00_SELECT_GE_ROT_ETAPA_DB_SELECT_1_Query1();
            var i = 0;
            dta.GE386_NOM_ROTINA = result[i++].Value?.ToString();
            dta.GE386_SEQ_ETAPA = result[i++].Value?.ToString();
            dta.GE386_DTH_INI_VIGENCIA = result[i++].Value?.ToString();
            dta.GE386_IND_TIPO_ETAPA = result[i++].Value?.ToString();
            dta.GE386_NOM_PROGRAMA = result[i++].Value?.ToString();
            dta.VIND_NOM_PROGRAMA = string.IsNullOrWhiteSpace(dta.GE386_NOM_PROGRAMA) ? "-1" : "0";
            dta.GE386_STA_ETAPA = result[i++].Value?.ToString();
            dta.GE386_QTD_EXEC_ETAPA = result[i++].Value?.ToString();
            return dta;
        }

    }
}