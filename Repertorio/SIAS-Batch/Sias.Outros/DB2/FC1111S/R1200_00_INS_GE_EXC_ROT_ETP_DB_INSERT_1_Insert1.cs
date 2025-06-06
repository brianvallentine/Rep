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
    public class R1200_00_INS_GE_EXC_ROT_ETP_DB_INSERT_1_Insert1 : QueryBasis<R1200_00_INS_GE_EXC_ROT_ETP_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL INSERT
            INTO SEGUROS.GE_EXEC_ROTINA_ETAPA
            (NOM_ROTINA,
            SEQ_ETAPA,
            DTH_INI_VIGENCIA,
            NUM_EXEC_ETAPA,
            DTA_INI_MOVIMENTO,
            DTA_FIM_MOVIMENTO,
            QTD_REG_LIDOS,
            QTD_REG_PROCS,
            QTD_REG_GRAVD,
            QTD_REG_ALTER,
            QTD_REG_EXCLU,
            STA_EXECUCAO,
            DTH_INI_EXECUCAO,
            DTH_FIM_EXECUCAO)
            VALUES
            (:GE387-NOM-ROTINA,
            :GE387-SEQ-ETAPA,
            :GE387-DTH-INI-VIGENCIA,
            :GE387-NUM-EXEC-ETAPA,
            CURRENT DATE,
            CURRENT DATE,
            :GE387-QTD-REG-LIDOS,
            :GE387-QTD-REG-PROCS,
            :GE387-QTD-REG-GRAVD,
            :GE387-QTD-REG-ALTER,
            :GE387-QTD-REG-EXCLU,
            :GE387-STA-EXECUCAO,
            CURRENT TIMESTAMP,
            NULL)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.GE_EXEC_ROTINA_ETAPA (NOM_ROTINA, SEQ_ETAPA, DTH_INI_VIGENCIA, NUM_EXEC_ETAPA, DTA_INI_MOVIMENTO, DTA_FIM_MOVIMENTO, QTD_REG_LIDOS, QTD_REG_PROCS, QTD_REG_GRAVD, QTD_REG_ALTER, QTD_REG_EXCLU, STA_EXECUCAO, DTH_INI_EXECUCAO, DTH_FIM_EXECUCAO) VALUES ({FieldThreatment(this.GE387_NOM_ROTINA)}, {FieldThreatment(this.GE387_SEQ_ETAPA)}, {FieldThreatment(this.GE387_DTH_INI_VIGENCIA)}, {FieldThreatment(this.GE387_NUM_EXEC_ETAPA)}, CURRENT DATE, CURRENT DATE, {FieldThreatment(this.GE387_QTD_REG_LIDOS)}, {FieldThreatment(this.GE387_QTD_REG_PROCS)}, {FieldThreatment(this.GE387_QTD_REG_GRAVD)}, {FieldThreatment(this.GE387_QTD_REG_ALTER)}, {FieldThreatment(this.GE387_QTD_REG_EXCLU)}, {FieldThreatment(this.GE387_STA_EXECUCAO)}, CURRENT TIMESTAMP, NULL)";

            return query;
        }
        public string GE387_NOM_ROTINA { get; set; }
        public string GE387_SEQ_ETAPA { get; set; }
        public string GE387_DTH_INI_VIGENCIA { get; set; }
        public string GE387_NUM_EXEC_ETAPA { get; set; }
        public string GE387_QTD_REG_LIDOS { get; set; }
        public string GE387_QTD_REG_PROCS { get; set; }
        public string GE387_QTD_REG_GRAVD { get; set; }
        public string GE387_QTD_REG_ALTER { get; set; }
        public string GE387_QTD_REG_EXCLU { get; set; }
        public string GE387_STA_EXECUCAO { get; set; }

        public static void Execute(R1200_00_INS_GE_EXC_ROT_ETP_DB_INSERT_1_Insert1 r1200_00_INS_GE_EXC_ROT_ETP_DB_INSERT_1_Insert1)
        {
            var ths = r1200_00_INS_GE_EXC_ROT_ETP_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1200_00_INS_GE_EXC_ROT_ETP_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}