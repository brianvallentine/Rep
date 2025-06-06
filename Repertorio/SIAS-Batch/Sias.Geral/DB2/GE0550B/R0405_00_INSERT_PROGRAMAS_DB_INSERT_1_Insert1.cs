using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Geral.DB2.GE0550B
{
    public class R0405_00_INSERT_PROGRAMAS_DB_INSERT_1_Insert1 : QueryBasis<R0405_00_INSERT_PROGRAMAS_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.AD_PROGRAMA
            (NOM_PROGRAMA ,
            DTH_INCLUSAO ,
            DTH_COMPILACAO,
            IND_PROGRAMA ,
            STA_DCLGEN ,
            STA_AMBIENTE ,
            DES_PROGRAMA ,
            COD_USUARIO ,
            DTH_TIMESTAMP )
            VALUES
            (:ADPROGRA-NOM-PROGRAMA,
            :ADPROGRA-DTH-INCLUSAO,
            :ADPROGRA-DTH-COMPILACAO,
            :ADPROGRA-IND-PROGRAMA,
            :ADPROGRA-STA-DCLGEN,
            :ADPROGRA-STA-AMBIENTE,
            :ADPROGRA-DES-PROGRAMA,
            :ADPROGRA-COD-USUARIO:WIND-COD-USUARIO,
            CURRENT TIMESTAMP)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.AD_PROGRAMA (NOM_PROGRAMA , DTH_INCLUSAO , DTH_COMPILACAO, IND_PROGRAMA , STA_DCLGEN , STA_AMBIENTE , DES_PROGRAMA , COD_USUARIO , DTH_TIMESTAMP ) VALUES ({FieldThreatment(this.ADPROGRA_NOM_PROGRAMA)}, {FieldThreatment(this.ADPROGRA_DTH_INCLUSAO)}, {FieldThreatment(this.ADPROGRA_DTH_COMPILACAO)}, {FieldThreatment(this.ADPROGRA_IND_PROGRAMA)}, {FieldThreatment(this.ADPROGRA_STA_DCLGEN)}, {FieldThreatment(this.ADPROGRA_STA_AMBIENTE)}, {FieldThreatment(this.ADPROGRA_DES_PROGRAMA)},  {FieldThreatment((this.WIND_COD_USUARIO?.ToInt() == -1 ? null : this.ADPROGRA_COD_USUARIO))}, CURRENT TIMESTAMP)";

            return query;
        }
        public string ADPROGRA_NOM_PROGRAMA { get; set; }
        public string ADPROGRA_DTH_INCLUSAO { get; set; }
        public string ADPROGRA_DTH_COMPILACAO { get; set; }
        public string ADPROGRA_IND_PROGRAMA { get; set; }
        public string ADPROGRA_STA_DCLGEN { get; set; }
        public string ADPROGRA_STA_AMBIENTE { get; set; }
        public string ADPROGRA_DES_PROGRAMA { get; set; }
        public string ADPROGRA_COD_USUARIO { get; set; }
        public string WIND_COD_USUARIO { get; set; }

        public static void Execute(R0405_00_INSERT_PROGRAMAS_DB_INSERT_1_Insert1 r0405_00_INSERT_PROGRAMAS_DB_INSERT_1_Insert1)
        {
            var ths = r0405_00_INSERT_PROGRAMAS_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0405_00_INSERT_PROGRAMAS_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}