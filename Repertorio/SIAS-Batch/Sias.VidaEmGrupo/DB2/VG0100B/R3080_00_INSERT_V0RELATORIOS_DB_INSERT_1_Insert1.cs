using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0100B
{
    public class R3080_00_INSERT_V0RELATORIOS_DB_INSERT_1_Insert1 : QueryBasis<R3080_00_INSERT_V0RELATORIOS_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL INSERT
            INTO SEGUROS.V0RELATORIOS
            VALUES (:V0RELT-COD-USUAR ,
            :V0RELT-DATA-SOLI ,
            'VG' ,
            :V0RELT-CODREL ,
            1 ,
            0 ,
            :V1SIST-DTMOVABE ,
            :V1SIST-DTMOVABE ,
            :V0RELT-DATA-REFER ,
            0 ,
            0 ,
            0 ,
            :V0RELT-FONTE ,
            0 ,
            0 ,
            0 ,
            0 ,
            :V1SOLF-NUM-APOL ,
            :V0RELT-NRENDOS ,
            0 ,
            0 ,
            0 ,
            :V0RELT-CODSUBES ,
            0 ,
            0 ,
            0 ,
            ' ' ,
            ' ' ,
            0 ,
            0 ,
            ' ' ,
            0 ,
            0 ,
            ' ' ,
            '0' ,
            ' ' ,
            ' ' ,
            :V0RELT-COD-EMPRESA:VIND-COD-EMP,
            :V0RELT-PERI-RENOVA:VIND-PERI-RENOVA,
            :V0RELT-PCT-AUMENTO:VIND-PCT-AUMENTO,
            CURRENT TIMESTAMP)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0RELATORIOS VALUES ({FieldThreatment(this.V0RELT_COD_USUAR)} , {FieldThreatment(this.V0RELT_DATA_SOLI)} , 'VG' , {FieldThreatment(this.V0RELT_CODREL)} , 1 , 0 , {FieldThreatment(this.V1SIST_DTMOVABE)} , {FieldThreatment(this.V1SIST_DTMOVABE)} , {FieldThreatment(this.V0RELT_DATA_REFER)} , 0 , 0 , 0 , {FieldThreatment(this.V0RELT_FONTE)} , 0 , 0 , 0 , 0 , {FieldThreatment(this.V1SOLF_NUM_APOL)} , {FieldThreatment(this.V0RELT_NRENDOS)} , 0 , 0 , 0 , {FieldThreatment(this.V0RELT_CODSUBES)} , 0 , 0 , 0 , ' ' , ' ' , 0 , 0 , ' ' , 0 , 0 , ' ' , '0' , ' ' , ' ' ,  {FieldThreatment((this.VIND_COD_EMP?.ToInt() == -1 ? null : this.V0RELT_COD_EMPRESA))},  {FieldThreatment((this.VIND_PERI_RENOVA?.ToInt() == -1 ? null : this.V0RELT_PERI_RENOVA))},  {FieldThreatment((this.VIND_PCT_AUMENTO?.ToInt() == -1 ? null : this.V0RELT_PCT_AUMENTO))}, CURRENT TIMESTAMP)";

            return query;
        }
        public string V0RELT_COD_USUAR { get; set; }
        public string V0RELT_DATA_SOLI { get; set; }
        public string V0RELT_CODREL { get; set; }
        public string V1SIST_DTMOVABE { get; set; }
        public string V0RELT_DATA_REFER { get; set; }
        public string V0RELT_FONTE { get; set; }
        public string V1SOLF_NUM_APOL { get; set; }
        public string V0RELT_NRENDOS { get; set; }
        public string V0RELT_CODSUBES { get; set; }
        public string V0RELT_COD_EMPRESA { get; set; }
        public string VIND_COD_EMP { get; set; }
        public string V0RELT_PERI_RENOVA { get; set; }
        public string VIND_PERI_RENOVA { get; set; }
        public string V0RELT_PCT_AUMENTO { get; set; }
        public string VIND_PCT_AUMENTO { get; set; }

        public static void Execute(R3080_00_INSERT_V0RELATORIOS_DB_INSERT_1_Insert1 r3080_00_INSERT_V0RELATORIOS_DB_INSERT_1_Insert1)
        {
            var ths = r3080_00_INSERT_V0RELATORIOS_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R3080_00_INSERT_V0RELATORIOS_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}