using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG5706B
{
    public class M_1400_LOOP_GRAVA_DB_INSERT_1_Insert1 : QueryBasis<M_1400_LOOP_GRAVA_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.V0COMISSAO
            VALUES (:SQL-NUM-APOL ,
            0,
            :SQL-NUM-CERT ,
            :SQL-DAC-CERT ,
            :SQL-TIPO-SEG ,
            0 ,
            1101,
            :SQL-COD-AGEN ,
            :SQL-RAMOFR ,
            0,
            0,
            :SQL-COD-FONTE,
            :SQL-COD-CLIE ,
            :SQL-VLCOMIS ,
            :SQL-DTMOVABE ,
            0,
            :SQL-VALBAS ,
            'O' ,
            0,
            :SQL-PCT-AGENC,
            0,
            :SQL-COD-SUB,
            :SQL-HORAOPER,
            NULL,
            :SQL-DATSEL:SQL-NOT-NULL,
            NULL,
            :SQL-PROPOSTA:SQL-NOT-NULL,
            CURRENT TIMESTAMP,
            :SQL-NUMBIL:SQL-NUMBILI,
            0,
            NULL)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0COMISSAO VALUES ({FieldThreatment(this.SQL_NUM_APOL)} , 0, {FieldThreatment(this.SQL_NUM_CERT)} , {FieldThreatment(this.SQL_DAC_CERT)} , {FieldThreatment(this.SQL_TIPO_SEG)} , 0 , 1101, {FieldThreatment(this.SQL_COD_AGEN)} , {FieldThreatment(this.SQL_RAMOFR)} , 0, 0, {FieldThreatment(this.SQL_COD_FONTE)}, {FieldThreatment(this.SQL_COD_CLIE)} , {FieldThreatment(this.SQL_VLCOMIS)} , {FieldThreatment(this.SQL_DTMOVABE)} , 0, {FieldThreatment(this.SQL_VALBAS)} , 'O' , 0, {FieldThreatment(this.SQL_PCT_AGENC)}, 0, {FieldThreatment(this.SQL_COD_SUB)}, {FieldThreatment(this.SQL_HORAOPER)}, NULL,  {FieldThreatment((this.SQL_NOT_NULL?.ToInt() == -1 ? null : this.SQL_DATSEL))}, NULL,  {FieldThreatment((this.SQL_NOT_NULL?.ToInt() == -1 ? null : this.SQL_PROPOSTA))}, CURRENT TIMESTAMP,  {FieldThreatment((this.SQL_NUMBILI?.ToInt() == -1 ? null : this.SQL_NUMBIL))}, 0, NULL)";

            return query;
        }
        public string SQL_NUM_APOL { get; set; }
        public string SQL_NUM_CERT { get; set; }
        public string SQL_DAC_CERT { get; set; }
        public string SQL_TIPO_SEG { get; set; }
        public string SQL_COD_AGEN { get; set; }
        public string SQL_RAMOFR { get; set; }
        public string SQL_COD_FONTE { get; set; }
        public string SQL_COD_CLIE { get; set; }
        public string SQL_VLCOMIS { get; set; }
        public string SQL_DTMOVABE { get; set; }
        public string SQL_VALBAS { get; set; }
        public string SQL_PCT_AGENC { get; set; }
        public string SQL_COD_SUB { get; set; }
        public string SQL_HORAOPER { get; set; }
        public string SQL_DATSEL { get; set; }
        public string SQL_NOT_NULL { get; set; }
        public string SQL_PROPOSTA { get; set; }
        public string SQL_NUMBIL { get; set; }
        public string SQL_NUMBILI { get; set; }

        public static void Execute(M_1400_LOOP_GRAVA_DB_INSERT_1_Insert1 m_1400_LOOP_GRAVA_DB_INSERT_1_Insert1)
        {
            var ths = m_1400_LOOP_GRAVA_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_1400_LOOP_GRAVA_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}